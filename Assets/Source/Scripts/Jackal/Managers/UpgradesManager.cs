using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    [SerializeField] private JackalMovement _player;
    [SerializeField] private JackalShoot _playerGun;

    public void Heal()
    {
        _player.Heal(20);
        _player.StopGame.Invoke();
        gameObject.SetActive(false);
    }

    public void AddDamage()
    {
        _playerGun.AddDamage(5);
        _player.StopGame.Invoke();
        gameObject.SetActive(false);
    }

    public void AddSpeed()
    {
        _player.AddSpeed(2f);
        _player.StopGame.Invoke();
        gameObject.SetActive(false);
    }
}
