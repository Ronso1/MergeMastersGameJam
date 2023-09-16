using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDIgenerator : MonoBehaviour
{
    [SerializeField] private float _levelOffset;
    [SerializeField] private int _levelLenght;
    private List<Pool<Chunk>> _levelPools = new List<Pool<Chunk>>();
    [SerializeField] private List<Chunk> _levelPrefs = new List<Chunk>();
    [SerializeField] private NavMeshSurface _navMesh;


    private Chunk levelPart;
    private Transform _player;

    private void Start()
    {
        for(int i = 0; i < _levelPrefs.Count; i++)
        {
            _levelPools.Add(new Pool<Chunk>(_levelPrefs[i], 4));
        }
        _player = FindFirstObjectByType<JackalMovement>().transform;
        SpawnChunks();
    }

    private void Update()
    {
        float diff = (transform.position - _player.position).magnitude;
        if (diff < _levelOffset * 2)
        {
            SpawnChunks();
        }
    }

    private void SpawnChunks()
    {
        for (int i = 0; i < _levelLenght - 1; i++)
        {
            levelPart = _levelPools[Random.Range(0, _levelPools.Count)].GetElement();
            levelPart.Reset();
            levelPart.transform.position = transform.position + Vector3.up * _levelOffset * (i + 1);
            levelPart.Hazard = Random.Range(1, 6);
            levelPart.Player = _player;
        }
        transform.position = levelPart.transform.position;
        _navMesh.UpdateNavMesh(_navMesh.navMeshData);
    }
}
