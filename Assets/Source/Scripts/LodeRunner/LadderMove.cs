using UnityEngine;

public class LadderMove : MonoBehaviour
{
    [SerializeField] private float _speedForClimb = 2f;

    private GameObject _player;
    private void Start() => _player = FindAnyObjectByType<PlayerMovement>().gameObject;

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().gravityScale = 0;
        var playerRB = collision.GetComponent<Rigidbody2D>();
        if (collision.gameObject == _player)
        {
            if (Input.GetKey(KeyCode.W))
            {
                playerRB.velocity = new Vector2(0, _speedForClimb);
            }
            else if ( Input.GetKey(KeyCode.S))
            {
                playerRB.velocity = new Vector2(0, -_speedForClimb);
            }
            else
            {
                playerRB.velocity = new Vector2(0, 0);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
