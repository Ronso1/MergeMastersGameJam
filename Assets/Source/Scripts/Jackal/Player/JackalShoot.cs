using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Linq;

public class JackalShoot : MonoBehaviour
{
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private JackalMovement _movement;
    [SerializeField] private Transform _gun;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private BulletConfig _bulletConfig;
    private int _damage = 0;
    private Pool<Bullet> _bulletPool;

    [SerializeField] private float _fireRate = 0.8f;
    [SerializeField] private float _fireRadius = 5f;
    private float _fireTimer = 0f;
    private int _sideMultiply = 1;
    private float _sizeMultiply = 0.2f;

    [Header("LayerMasks")]
    [SerializeField] private LayerMask _layersForAutoAttack;
    [SerializeField] private LayerMask _layerMaskForEnemyRaycast;

    private void Start()
    {
        _bulletPool = new Pool<Bullet>(_bulletPrefab, 15);
    }

    private void Update()
    {
        if (_fireTimer > _fireRate && !_movement.IsStop)
        {
            if (!AutoAttack())
                return;
            _fireTimer = 0;
        }
        _fireTimer += Time.deltaTime;
    }

    private bool AutoAttack()
    {
        List<Collider2D> targets = Physics2D.OverlapCircleAll(transform.position, _fireRadius, _layersForAutoAttack).ToList();
        RemoveNotInRaycast(ref targets);
        Collider2D finalTarget = null;
        float minDistance = _fireRadius;

        if (targets.Count == 0)
        {
            return false;
        }

        foreach (var target in targets)
        {
            float distance = Distance(target.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                finalTarget = target;
            }
        }

        if (finalTarget != null)
        {
            Vector3 diff = finalTarget.transform.position - _gun.position;
            float angle = Vector2.SignedAngle(Vector2.right, diff);
            _gun.eulerAngles = new Vector3(0, 0, angle);
        }

        Shoot();

        return true;
    }

    private void RemoveNotInRaycast(ref List<Collider2D> targets)
    {
        List<Collider2D> tempList = new List<Collider2D>();
        foreach (var target in targets)
        {
            Vector2 diff = target.transform.position - _gun.position;
            RaycastHit2D hit = Physics2D.Raycast(_gun.position, diff, _fireRadius, _layerMaskForEnemyRaycast);
            if (hit.collider == null || hit.collider.tag != "Enemy")
            {
                tempList.Add(target);
            }
        }
        targets.RemoveAll(t => tempList.Contains(t));
    }

    private float Distance(Vector3 target)
    {
        return (target - transform.position).magnitude;
    }

    private void Shoot()
    {
        for (int j = 0; j < _sideMultiply; j++)
        {
            Bullet bullet = _bulletPool.GetElement();
            bullet.transform.localScale = Vector2.one * _sizeMultiply;
            bullet.SetDamage(_damage);
            float angle = 15f * Mathf.Pow(-1, j + 1) * Mathf.CeilToInt(j / 2f);
            bullet._directon = _gun.rotation * Quaternion.Euler(0, 0, angle) * Vector2.right;
            bullet.SetConfig(_bulletConfig);
            bullet.Reset();
            bullet.transform.position = _shootPosition.position;
        }
    }

    public void ChangeBullet(BulletConfig config)
    {
        _bulletConfig = config;
    }

    public void AddDamage(int damage)
    {
        _damage += damage;
    }

    public void IncreaceSide()
    {
        _sideMultiply += 2;
    }

    public void IncreaceForward()
    {
        _fireRate /= 1.2f;
    }

    public void IncreaceSize()
    {
        _sizeMultiply *= 1.2f;
    }
}
