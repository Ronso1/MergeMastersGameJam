using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackalShoot : MonoBehaviour
{
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private Transform _gun;
    [SerializeField] private Bullet _bulletPrefab;
    private Pool<Bullet> _bulletPool;

    private void Start()
    {
        _bulletPool = new Pool<Bullet>(_bulletPrefab, 15);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Bullet bullet = _bulletPool.GetElement();
        bullet.Reset();
        bullet.transform.position = _shootPosition.position;
        bullet._directon = _gun.rotation * Vector2.up;
    }
}
