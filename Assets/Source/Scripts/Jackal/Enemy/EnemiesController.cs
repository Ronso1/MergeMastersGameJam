using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    private List<Enemy> _enemies = new List<Enemy>();
    private Pool<Bullet> _enemyBullets;
    [SerializeField] private Bullet _bulletPrefab;

    private void Start()
    {
        _enemyBullets = new Pool<Bullet>(_bulletPrefab, 30);
        foreach (Enemy enemy in FindObjectsOfType<Enemy>())
        {
            _enemies.Add(enemy);
            enemy.BulletPool = _enemyBullets;
        }
    }
}
