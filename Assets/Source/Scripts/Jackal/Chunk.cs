using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour, Poolable
{
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
    [SerializeField] private List<NavMeshModifier> _nvModifiers = new List<NavMeshModifier>();

    public List<Enemy> Enemies { get { return _enemies; } }
    public int Hazard { get; set; }
    public Transform Player { get; set; }

    private void Start()
    {
        int enemyHazard = Hazard * 50;
        List<Enemy> activeEnemies = new List<Enemy>();
        foreach(Enemy enemy in _enemies)
        {
            enemyHazard -= enemy.Hazard;
            if(enemyHazard > 0)
            {
                enemy.gameObject.SetActive(true);
                activeEnemies.Add(enemy);
                continue;
            }
            break;
        }
        FindFirstObjectByType<EnemiesController>().NewChunk(activeEnemies);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out CameraCollider _))
        {
            gameObject.SetActive(false);
        }
    }

    public void Reset()
    {
        gameObject.SetActive(true);
    }
}
