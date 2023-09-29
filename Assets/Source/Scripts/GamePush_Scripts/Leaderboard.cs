using UnityEngine;
using GamePush;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] public CalculateDistance score;
    public void ShowLeaderboard()
    {
        GP_Player.Set("score", score.playerScoreInt);
        print(score.playerScoreInt);
        GP_Leaderboard.Open();
    }
}

