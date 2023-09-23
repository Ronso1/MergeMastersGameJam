using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, Poolable
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private Rigidbody2D _rigidbody;
    [HideInInspector] public Vector2 _directon;
    [SerializeField] private string _tag;

    private void FixedUpdate()
    {
        _rigidbody.velocity = _directon * _speed;
    }

    public void Reset()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Damagable damagable))
        {
            damagable.GetDamage(_damage);
        }
        gameObject.SetActive(false);
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }
}
