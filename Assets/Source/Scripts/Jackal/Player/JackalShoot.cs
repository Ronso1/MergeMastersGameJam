using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackalShoot : MonoBehaviour
{
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private JackalMovement _movement;
    [SerializeField] private Transform _gun;
    [SerializeField] private Bullet _bulletPrefab;
    private int _damage = 0;
    private Pool<Bullet> _bulletPool;

    private void Start()
    {
        _bulletPool = new Pool<Bullet>(_bulletPrefab, 15);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !_movement.IsStop)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Bullet bullet = _bulletPool.GetElement();
        bullet.SetDamage(_damage);
        bullet._directon = _gun.rotation * Vector2.right;
        bullet.Reset();
        bullet.transform.position = _shootPosition.position;
    }

    public void AddDamage( int damage)
    {
        _damage += damage;
    }
}
