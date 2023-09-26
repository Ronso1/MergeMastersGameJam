using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private LevelDigenerator _digenerator;
    [SerializeField] private EnemiesController _enemiesController;
    
    private void Awake()
    {
        _enemiesController.Init();
        _digenerator.Init();
    }
}