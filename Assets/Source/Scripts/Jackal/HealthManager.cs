using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager
{
    private int _maxHealth;
    private int _health;

    public int Health { get { return _health; } }

    public HealthManager(int maxHealth) 
    {
        _maxHealth = maxHealth;
        _health = _maxHealth;
    }

    public void GetDamage(int damage)
    {
        _health -= damage;
    }
}
