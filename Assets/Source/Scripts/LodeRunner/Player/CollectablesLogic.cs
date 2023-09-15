using UnityEngine;
public class CollectablesLogic : MonoBehaviour
{
    private GameObject _playerGoldScore;

    private void Start()
    {
        _playerGoldScore = FindAnyObjectByType<PlayerMovement>().gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _playerGoldScore)
        {
            _playerGoldScore.GetComponent<PlayerMovement>().PlayerScore++;
            _playerGoldScore.GetComponent<PlayerMovement>().ShowInfoAboutScore();
            transform.gameObject.SetActive(false);
        }
    }
}
