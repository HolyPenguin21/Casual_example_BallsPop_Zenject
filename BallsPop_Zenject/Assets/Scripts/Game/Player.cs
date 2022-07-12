using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int curHealth;
    public int CurHealth
    {
        get { return curHealth; }
    }

    private int currentScore;
    public int CurrentScore
    {
        get { return currentScore; }
    }

    int maxHealth = 3;

    EventsHandler eventsHandler;

    public Player(EventsHandler eventsHandler)
    {
        this.eventsHandler = eventsHandler;

        this.eventsHandler.onGameStart += ResetScore;
        this.eventsHandler.onGameStart += Set_MaxHealth;

        this.eventsHandler.onBallDestroyed += Add_Score;

        this.eventsHandler.onBallMissed += Remove_Score;
        this.eventsHandler.onBallMissed += RemoveHealth;

        this.eventsHandler.onGameRestart += ResetScore;
        this.eventsHandler.onGameRestart += Set_MaxHealth;

        Set_MaxHealth();
    }

    private void RemoveHealth(int value)
    {
        curHealth -= Mathf.Abs(value);

        if (curHealth <= 0)
        {
            eventsHandler.On_GameEnd();
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
