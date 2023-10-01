using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    [SerializeField] private Transform _car;
    private Transform _newPoint;
    private float _speed = 2f;

    private void Start()
    {
        _newPoint = _car.transform;
    }

    private void Update()
    {
        _car.Translate(0f, -(_car.position.x - _speed - Time.time) * Time.deltaTime, 0f);


    }

}
