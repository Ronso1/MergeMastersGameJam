using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _upgrades = new List<GameObject>();
    [SerializeField] private JackalMovement _player;
    [SerializeField] private JackalShoot _playerGun;

    public void ShowUpgrades()
    {
        for(int i = 0; i < 3;  i++)
        {
            var chosenUpgrade = _upgrades[Random.Range(0, _upgrades.Count)];
            chosenUpgrade.SetActive(true);
        }
    }

    private void HideUpgrades()
    {
        foreach(var upgrade in _upgrades)
        { 
            upgrade.SetActive(false); 
        }
    }

    public void ChengeBullet(BulletConfig config)
    {
        _playerGun.ChangeBullet(config);
        UpgradesEnd();
    }

    public void Heal()
    {
        _player.Heal(20);
        UpgradesEnd();
    }

    public void AddDamage()
    {
        _playerGun.AddDamage(5);
        UpgradesEnd();
    }

    public void AddSpeed()
    {
        _player.AddSpeed(2f);
        UpgradesEnd();
    }

    private void UpgradesEnd()
    {
        _player.StopGame.Invoke();
        gameObject.SetActive(false);
        HideUpgrades();
    }
}
