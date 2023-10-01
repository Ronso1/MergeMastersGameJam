using UnityEngine;
using GamePush;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private Button _showLeaderboard;
    private void Awake()
    {
        _showLeaderboard.onClick.AddListener(ShowLeaderboard);
    }

    private void ShowLeaderboard()
    {
        GP_Leaderboard.Fetch();
        GP_Leaderboard.Open("score");
    }

}

