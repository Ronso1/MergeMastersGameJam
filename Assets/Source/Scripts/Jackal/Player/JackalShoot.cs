using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

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
    private float _fireTimer = 0f;
    private int _sideMultiply = 1;
    private int _forwardMultiply = 1;
    private float _sizeMultiply = 0.2f;

    private void Start()
    {
        _bulletPool = new Pool<Bullet>(_bulletPrefab, 15);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && _fireTimer > _fireRate && !_movement.IsStop)
        {
            Shoot();
            _fireTimer = 0;
        }
        _fireTimer += Time.deltaTime;
    }

    private async void Shoot()
    {
        for(int i = 0; i < _forwardMultiply; i++)
        {
            for(int j = 0; j < _sideMultiply; j++)
            {
                Bullet bullet = _bulletPool.GetElement();
                bullet.transform.localScale = Vector2.one * _sizeMultiply;
                bullet.SetDamage(_damage);
                float angle = 15f * Mathf.Pow(-1, j + 1) * Mathf.CeilToInt(j / 2f);
                bullet._directon = _gun.rotation * Quaternion.Euler(0, 0, angle) * Vector2.right;
                Debug.Log(_gun.rotation.z);
                bullet.SetConfig(_bulletConfig);
                bullet.Reset();
                bullet.transform.position = _shootPosition.position;
            }
            await UniTask.Delay(275);
        }
    }

    public void ChangeBullet(BulletConfig config)
    {
        _bulletConfig = config;
    }

    public void AddDamage( int damage)
    {
        _damage += damage;
    }

    public void IncreaceSide()
    {
        _sideMultiply += 2;
    }

    public void IncreaceForward()
    {
        _forwardMultiply++;
    }

    public void IncreaceSize()
    {
        _sizeMultiply *= 1.2f;
    }
}
