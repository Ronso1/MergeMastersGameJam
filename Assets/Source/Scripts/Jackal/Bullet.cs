using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Bullet : MonoBehaviour, Poolable
{
    [SerializeField] private float _speed;
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
        if (other.gameObject.tag == _tag)
        {
            Debug.Log("Õ≈√–€ œ»ƒ¿–¿—€");
        }
        gameObject.SetActive(false);
    }
}
