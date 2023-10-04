using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspectController : MonoBehaviour
{
    [SerializeField] private Vector2 DefaultResolution = new Vector2(720, 1280);
    [SerializeField, Range(0f, 1f)] private float WidthOrHeight = 0;

    private Camera componentCamera;

    private float initialSize;
    private float targetAspect;

    private void Start()
    {
        componentCamera = GetComponent<Camera>();
        initialSize = componentCamera.orthographicSize;

        targetAspect = DefaultResolution.x / DefaultResolution.y;
    }

    private void Update()
    {
        float constantWidthSize = initialSize * (targetAspect / componentCamera.aspect);
        componentCamera.orthographicSize = Mathf.Lerp(constantWidthSize, initialSize, WidthOrHeight);
    }
}
