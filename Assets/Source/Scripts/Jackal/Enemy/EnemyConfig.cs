using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Enemy Config", menuName = "Enemy Config")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _idleDistance;
    [SerializeField] private float _attackDistance;

    public float Speed { get { return _speed; } }
    public float IdleDistance { get { return _idleDistance; } }
    public float AttackDistance { get { return _attackDistance; } }
}
