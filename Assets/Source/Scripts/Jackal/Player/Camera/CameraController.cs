using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _player;
    private float _maxPos;

    private void Start()
    {
        _player = FindFirstObjectByType<JackalMovement>().transform;
        _maxPos = _player.position.y;
    }

    private void Update()
    {
        if(_player.position.y > _maxPos)
            transform.position = new Vector3(-4, _maxPos = _player.position.y, -10);

    }
}
