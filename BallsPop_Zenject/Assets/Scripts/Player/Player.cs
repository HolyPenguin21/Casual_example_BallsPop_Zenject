using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IPlayer
{
    private int curHealth;
    private int currentScore;
    int maxHealth = 3;

    IGameStateHandler gameStateHandler;

    public Player(IGameStateHandler gameStateHandler, IBallEventsHandler ballEventsHandler)
    {
        this.gameStateHandler = gameStateHandler;

        this.gameStateHandler.Add_GameStartListener(ResetScore);
        this.gameStateHandler.Add_GameStartListener(Set_MaxHealth);
        this.gameStateHandler.Add_GameRestartListener(ResetScore);
        this.gameStateHandler.Add_GameRestartListener(Set_MaxHealth);

        ballEventsHandler.Add_BallDestroyedListener(Add_Score);
        ballEventsHandler.Add_BallMissedListener(Remove_Score);
        ballEventsHandler.Add_BallMissedListener(RemoveHealth);

        Set_MaxHealth();
    }

    public int Get_CurrentHealth()
    {
        return curHealth;
    }

    public int Get_CurrentScore()
    {
        return currentScore;
    }

    private void RemoveHealth(int value)
    {
        curHealth -= Mathf.Abs(value);

        if (curHealth <= 0)
        {
            gameStateHandler.Invoke_GameEnd();
        }
    }

    private void Set_MaxHealth()
    {
        curHealth = maxHealth;
    }

    private void Add_Score(int value)
    {
        currentScore += value;
    }

    private void Remove_Score(int value)
    {
        currentScore -= value * 5;
    }

    private void ResetScore()
    {
        currentScore = 0;
    }
}
