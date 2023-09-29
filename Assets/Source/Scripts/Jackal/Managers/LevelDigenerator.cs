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

    #region LevelPartsPools
    private List<Pool<Chunk>> _levelPools = new List<Pool<Chunk>>();
    [SerializeField] private List<Chunk> _levelPrefs = new List<Chunk>();

    private List<Pool<Chunk>> _levelStartPool = new List<Pool<Chunk>>();
    [SerializeField] private List<Chunk> _levelStartPrefs = new List<Chunk>();

    private List<Pool<Chunk>> _levelEndPool = new List<Pool<Chunk>>();
    [SerializeField] private List<Chunk> _levelEndPrefs = new List<Chunk>();

    private List<Pool<Chunk>> _levelLoadingPool = new List<Pool<Chunk>>();
    [SerializeField] private List<Chunk> _levelLoadingPrefs = new List<Chunk>();
    #endregion

    [SerializeField] private NavMeshSurface _navMesh;

    private Chunk levelPart;
    private Transform _player;

    public void Init()
    {
        for(int i = 0; i < _levelPrefs.Count; i++)
        {
            _levelPools.Add(new Pool<Chunk>(_levelPrefs[i], 4));
        }

        AddChunkPool(_levelStartPrefs, _levelStartPool);
        AddChunkPool(_levelEndPrefs, _levelEndPool);
        AddChunkPool(_levelLoadingPrefs, _levelLoadingPool);

        _player = FindFirstObjectByType<JackalMovement>().transform;

        SpawnChunks();
    }

    private void AddChunkPool(List<Chunk> chunkPrefs, List<Pool<Chunk>> pools)
    {
        foreach (var chunk in chunkPrefs)
        {
            pools.Add(new Pool<Chunk>(chunk, 2));
        }
    }

    private void Update()
    {
        float diff = (transform.position - _player.position).magnitude;
        if (diff < _levelOffset)
        {
            SpawnChunks();
        }
    }

    private void SpawnChunks()
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

        CheateLoadPart();
    }

    private void CheateLoadPart()
    {
        CreateLoadChunk(_levelEndPool[Random.Range(0, _levelEndPool.Count)].GetElement());
        CreateLoadChunk(_levelLoadingPool[Random.Range(0, _levelLoadingPool.Count)].GetElement());
        CreateLoadChunk(_levelLoadingPool[Random.Range(0, _levelLoadingPool.Count)].GetElement());
        CreateLoadChunk(_levelStartPool[Random.Range(0, _levelStartPool.Count)].GetElement());
    }

    private void CreateLoadChunk(Chunk chunk)
    {
        chunk.transform.position = transform.position + Vector3.up * _levelOffset;
        chunk.gameObject.SetActive(true);
        transform.position = chunk.transform.position;
    }
}
