using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.AI;

public class LevelDigenerator : MonoBehaviour
{
    [SerializeField] private float _levelOffset;
    [SerializeField] private int _levelLenght;
    private List<Pool<Chunk>> _levelPools = new List<Pool<Chunk>>();
    [SerializeField] private List<Chunk> _levelPrefs = new List<Chunk>();
    [SerializeField] private NavMeshSurface _navMesh;

    private Chunk levelPart;
    private Transform _player;

    public async void Init()
    {
        for(int i = 0; i < _levelPrefs.Count; i++)
        {
            _levelPools.Add(new Pool<Chunk>(_levelPrefs[i], 4));
        }
        _player = FindFirstObjectByType<JackalMovement>().transform;

        SpawnChunks();
    }

    private async void Update()
    {
        float diff = (transform.position - _player.position).magnitude;
        if (diff < _levelOffset * 2)
        {
            SpawnChunks();
        }
    }

    private async UniTask SpawnChunks()
    {
        for (int i = 1; i < _levelLenght; i++)
        {
            levelPart = _levelPools[Random.Range(0, _levelPools.Count)].GetElement(); 
            levelPart.Hazard = Random.Range(1, 4);
            levelPart.Player = _player;

            levelPart.transform.position = transform.position + Vector3.up * _levelOffset;
            transform.position = levelPart.transform.position;

            levelPart.Reset();
        }

        _navMesh.UpdateNavMesh(_navMesh.navMeshData);
    }
}
