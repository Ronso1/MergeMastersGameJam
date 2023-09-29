using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, Poolable
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private BulletConfig _config;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [HideInInspector] public Vector2 _directon;

    private int _damageToAdd = 0;

    private void FixedUpdate()
    {
        _rigidbody.velocity = _directon * _config.Speed;
    }

    public void Reset()
    {
        gameObject.SetActive(true);
        _spriteRenderer.sprite = _config.Sprite;
        transform.eulerAngles = new Vector3(0,0, Vector2.SignedAngle(Vector2.up, _directon));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Damagable damagable))
        {
            damagable.GetDamage(_config.Damage + _damageToAdd);
        }
        gameObject.SetActive(false);
    }

    public void SetDamage(int damage)
    {
        _damageToAdd += damage;
    }
}
