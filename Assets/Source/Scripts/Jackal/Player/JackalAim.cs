using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackalAim : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector2 diff = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, diff);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
