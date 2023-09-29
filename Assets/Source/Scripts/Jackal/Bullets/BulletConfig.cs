using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bullet Config", fileName = "new Bullet Config")]
public class BulletConfig : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private string _tag;

    public Sprite Sprite { get { return _sprite; } }
    public float Speed { get { return _speed;} }
    public int Damage { get { return _damage; } }
    public string Tag { get { return _tag;} }

}
