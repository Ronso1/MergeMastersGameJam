using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDIgenerator : MonoBehaviour
{
    [SerializeField] private float _levelOffset;
    [SerializeField] private int _levelLenght;
    [SerializeField] private GameObject[] _levelPrefabs;

    private void Start()
    {
        for(int i = 0; i < _levelLenght-1; i++)
        {
            var levelPart = _levelPrefabs[Random.Range(0, _levelPrefabs.Length)];
            levelPart.transform.position = Vector2.up * _levelOffset * (i + 1);
        }
    }

}
