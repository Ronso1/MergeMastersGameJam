using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    [SerializeField] private Transform _car;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private GameObject _firstLoop;

    private float _positionToChangeChunk = 32f;
    private float _positionToChange = 65f;
    public List<GameObject> _chunks;
    private int _count = 0;


    private void Start()
    {
        _chunks.Add(_firstLoop);
    }

    private void Update()
    {
        _car.Translate(0f, -(_car.position.x - _speed) * Time.deltaTime, 0f);
        _speed += 5f * Time.deltaTime;
        if (_car.transform.position.x >= _positionToChangeChunk)
        {
                                 
            var chunk = Instantiate(_firstLoop);
            chunk.transform.position = new Vector3(_positionToChange, 0f, 0f);
            _chunks.Add(chunk);                       
            _positionToChange += 65f;
            _count++;
            _chunks[_count].SetActive(true);
            _positionToChangeChunk += 32f;
        }
       
    }

}
