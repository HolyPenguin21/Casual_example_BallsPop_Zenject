using UnityEngine;

public class ScoreManager
{
    Player player;

    public ScoreManager(EventsHandler eventsHandler, Player player)
    {
        this.player = player;

        eventsHandler.onGameEnd += Set_HighScore;
    }

    private void Set_HighScore()
    {
        int currentScore = player.CurrentScore;

        if (currentScore > Get_HighScore())
            PlayerPrefs.SetInt("highScore", currentScore);
    }

    private int Get_HighScore()
    {
        return PlayerPrefs.GetInt("highScore");
    }
}
