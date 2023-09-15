using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, Poolable
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [HideInInspector] public Vector2 _directon;

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
        if(other.TryGetComponent(out Enemy enemy))
        {

        }
    }
}
