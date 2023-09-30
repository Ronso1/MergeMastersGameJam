using UnityEngine;
using GamePush;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] public CalculateDistance score;
    [SerializeField] private TMP_Text _showScore; 
    public void ShowLeaderboard()
    {
        if ((int)GP_Player.GetScore() < score.playerScoreInt)
        {
            GP_Player.SetScore(score.playerScoreInt);
            GP_Player.Sync(true);           
        }
        GP_Leaderboard.FetchPlayerRating();
        print(score.playerScoreInt);
        GP_Leaderboard.Open("score");
    }

}

