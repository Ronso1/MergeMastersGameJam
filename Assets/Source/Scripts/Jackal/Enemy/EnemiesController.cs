using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    private List<Enemy> _enemies = new List<Enemy>();
    private Pool<Bullet> _enemyBullets;
    private Pool<Drop> _enemyDrops;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Drop _dropPrefab;
    [SerializeField] private Transform _player;

    private void Start()
    {
        _enemyBullets = new Pool<Bullet>(_bulletPrefab, 30);
        _enemyDrops = new Pool<Drop>(_dropPrefab, 20);
        foreach (Enemy enemy in FindObjectsOfType<Enemy>())
        {
            _enemies.Add(enemy);
            enemy.BulletPool = _enemyBullets;
            enemy.DropPool = _enemyDrops;
            enemy.SetPlayer(_player);
        }
    }

    public void NewChunk(List<Enemy> enemies)
    {
        foreach (Enemy enemy in enemies)
        {
            _enemies.Add(enemy);
            enemy.BulletPool = _enemyBullets;
            enemy.DropPool = _enemyDrops;
            enemy.SetPlayer(_player);
        }
    }
}
