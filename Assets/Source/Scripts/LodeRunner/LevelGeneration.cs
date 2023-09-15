using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> _poolLevels;
    private GameObject _firstLevel;
    private GameObject _secondLevel;
    private Vector2 _positionOfFirstPartLvl = new Vector2(0f, 0f);
    private Vector2 _positionOfSecondPartLvl = new Vector2(56f, 0f);


    private void Awake()
    {
        SelectPartOfLevel();
    }

    private void SelectPartOfLevel()
    {
        RandomGenerate();     
        while (_firstLevel == _secondLevel)
        {
            RandomGenerate();
        }
        _firstLevel.transform.position = _positionOfFirstPartLvl;
        _secondLevel.transform.position = _positionOfSecondPartLvl;
        Instantiate(_firstLevel);
        Instantiate(_secondLevel);
    }

    private void RandomGenerate()
    {
        int countOfParts = _poolLevels.Count;
        _firstLevel = _poolLevels[Random.Range(0, countOfParts)];
        _secondLevel = _poolLevels[Random.Range(0, countOfParts)];
    }
}
