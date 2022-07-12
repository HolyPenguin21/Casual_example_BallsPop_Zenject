using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsHandler
{
    public delegate void OnGameStart();
    public event OnGameStart onGameStart;

    public delegate void OnGameEnd();
    public event OnGameEnd onGameEnd;

    public delegate void OnGameRestart();
    public event OnGameRestart onGameRestart;

    public delegate void OnGamePause();
    public event OnGamePause onGamePause;

    public delegate void OnGameUnpause();
    public event OnGameUnpause onGameUnpause;

    public delegate void OnBallDestroyed(int value);
    public event OnBallDestroyed onBallDestroyed;

    public delegate void OnBallDestroyedEffect(Vector3 pos);
    public event OnBallDestroyedEffect onBallDestroyedEffect;

    public delegate void OnBallMissed(int value);
    public event OnBallMissed onBallMissed;

    public delegate void OnScoreUpdate();
    public event OnScoreUpdate onScoreUpdate;


    public void On_GameStart()
    {
        onGameStart?.Invoke();
    }

    public void On_GameEnd()
    {
        onGameEnd?.Invoke();
    }

    public void On_GameRestart()
    {
        onGameRestart?.Invoke();

        Time.timeScale = 1; // Review
    }

    public void On_GamePause()
    {
        onGamePause?.Invoke();

        Time.timeScale = 0; // Review
    }

    public void On_GameUnpause()
    {
        onGameUnpause?.Invoke();

        Time.timeScale = 1; // Review
    }

    public void On_BallDestroyed(int value)
    {
        onBallDestroyed?.Invoke(value);
        onScoreUpdate?.Invoke();
    }

    public void On_BallDestroyedEffect(Vector3 pos)
    {
        onBallDestroyedEffect?.Invoke(pos);
    }

    public void On_BallMissed(int value)
    {
        onBallMissed?.Invoke(value);
        onScoreUpdate?.Invoke();
    }

    public void RemoveSubscribtions()
    {
        onGameStart = null;
        onGameEnd = null;
        onGameRestart = null;
        onGamePause = null;
        onGameUnpause = null;
        onBallDestroyed = null;
        onBallDestroyedEffect = null;
        onBallMissed = null;
        onScoreUpdate = null;
    }
}
