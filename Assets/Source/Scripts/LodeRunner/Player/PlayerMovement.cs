using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private void Update()
    {
        var Horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Horizontal * _speed * Time.deltaTime, 0f, 0f);
    }
}