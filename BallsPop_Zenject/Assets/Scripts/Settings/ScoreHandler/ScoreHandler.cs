using UnityEngine;

public class ScoreHandler : IScoreHandler
{
    IPlayer player;

    public ScoreHandler(IPlayer player, IGameStateHandler gameStateHandler)
    {
        this.player = player;

        gameStateHandler.Add_GameEndListener(Update_HighScore);
    }

    public int Get_HighScore()
    {
        return PlayerPrefs.GetInt("highScore");
    }

    public void Update_HighScore()
    {
        int currentScore = player.Get_CurrentScore();

        if (currentScore > Get_HighScore())
            PlayerPrefs.SetInt("highScore", currentScore);
    }
}
