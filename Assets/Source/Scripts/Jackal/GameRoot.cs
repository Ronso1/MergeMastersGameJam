using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private LevelDigenerator _digenerator;
    [SerializeField] private EnemiesController _enemiesController;

    [SerializeField] private Joystick _joystick;

    private void Start()
    {
        _enemiesController.Init();
        _digenerator.Init();

        if (GamePush.GP_Device.IsMobile())
        {
            _joystick.enabled = true;
        }
    }
}
