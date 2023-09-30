using UnityEngine;
using TMPro;

public class CalculateDistance : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private TMP_Text _distance;

    private float _startPoint = 0f;
    public float playerScore;
    public int playerScoreInt;

    private void Awake()
    {
        _startPoint = _player.transform.position.y;

    }

    private void Update()
    {
        playerScore = _player.transform.position.y - _startPoint;
        playerScoreInt = (int)playerScore;
        _distance.text = "Distance: " + playerScoreInt;

    }
}
