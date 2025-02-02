using System;
using UnityEngine;

public class GameStateHandler : IGameStateHandler, IDisposable
{
    event IGameStateHandler.OnGameStart onGameStart;
    event IGameStateHandler.OnGameEnd onGameEnd;
    event IGameStateHandler.OnGameRestart onGameRestart;

    public void Add_GameEndListener(IGameStateHandler.OnGameEnd method)
    {
        onGameEnd += method;
    }

    public void Add_GameRestartListener(IGameStateHandler.OnGameRestart method)
    {
        onGameRestart += method;
    }

    public void Add_GameStartListener(IGameStateHandler.OnGameStart method)
    {
        onGameStart += method;
    }

    public void Invoke_GameEnd()
    {
        onGameEnd?.Invoke();
    }

    public void Invoke_GameRestart()
    {
        onGameRestart?.Invoke();
        Time.timeScale = 1.0f; // Review
    }

    public void Invoke_GameStart()
    {
        onGameStart?.Invoke();
    }

    public void Dispose()
    {
        onGameStart = null;
        onGameEnd = null;
        onGameRestart = null;
    }
}
