using UnityEngine;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private TMP_Text _playerScoreInfo;
    public int PlayerScore = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        _playerScoreInfo.text = $"Gold: {PlayerScore}"; 
        var Horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Horizontal * _speed * Time.deltaTime, 0f, 0f);
    }
}