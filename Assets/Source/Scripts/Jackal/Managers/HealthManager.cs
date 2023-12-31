using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager
{
    private int _maxHealth;
    private int _health;

    public int Health { get { return _health; } }
    public int MaxHealth { get { return _maxHealth; } }

    public HealthManager(int maxHealth) 
    {
        _maxHealth = maxHealth;
        _health = _maxHealth;
    }

    public void GetDamage(int damage)
    {
        _health -= damage;
    }

    public void Heal(int hp)
    {
        _health += hp;
    }
    public void IncreaceHp(int multiply)
    {
        _maxHealth *= multiply;
        _health *= multiply;
    }

    public void Reset()
    {
        _health = _maxHealth;
    }
}
