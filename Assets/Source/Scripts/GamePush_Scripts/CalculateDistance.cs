using UnityEngine;
using TMPro;

public class CalculateDistance : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private TMP_Text _distance;

    private int _startPoint = 0;
    public static int playerScore;

    private void Awake()
    {
        _startPoint = Mathf.CeilToInt(_player.position.y);

    }

    private void Update()
    {
        playerScore = Mathf.CeilToInt(_player.position.y) - _startPoint;
        _distance.text = "Distance: " + (int)playerScore;

    }
}
