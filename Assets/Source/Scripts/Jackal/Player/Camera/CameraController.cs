using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _player;
    private Camera _thisCamera;
    [SerializeField] private Transform _collider;
    private float _maxPos;

    private void Start()
    {
        _player = FindFirstObjectByType<JackalMovement>().transform;
        _maxPos = _player.position.y;

        _thisCamera = GetComponent<Camera>();
        _collider.position = Vector2.down * (_thisCamera.orthographicSize + 0.5f);
    }

    private void Update()
    {
        if(_player.position.y > _maxPos)
            transform.position = new Vector3(-4, _maxPos = _player.position.y, -10);

        _collider.position = Vector2.down * (_thisCamera.orthographicSize + 0.5f);
    }
}
