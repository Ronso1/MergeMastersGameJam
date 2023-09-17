using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour, Poolable
{
    public Transform Player;
    public Vector2 SecondPoint;
    private float t = 0;

    [SerializeField] private float _speed = 0.1f;

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, Player.position, t * _speed);
        t += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out JackalMovement jackalMovement))
        {
            jackalMovement.AddLevelPoints();
            gameObject.SetActive(false);
        }
    }

    public void Reset()
    {
        gameObject.SetActive(true);
    }
}
