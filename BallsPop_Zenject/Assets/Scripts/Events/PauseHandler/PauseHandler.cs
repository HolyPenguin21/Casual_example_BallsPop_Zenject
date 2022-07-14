using System;
using UnityEngine;

public class PauseHandler : IPauseHandler, IDisposable
{
    event IPauseHandler.OnGamePause onGamePause;
    event IPauseHandler.OnGameResume onGameResume;

    public void Add_PauseListener(IPauseHandler.OnGamePause method)
    {
        onGamePause += method;
    }

    public void Invoke_Pause()
    {
        onGamePause?.Invoke();
        Time.timeScale = 0.0f;
    }

    public void Add_ResumeListener(IPauseHandler.OnGameResume method)
    {
        onGameResume += method;
        Time.timeScale = 1.0f;
    }

    public void Invoke_Resume()
    {
        onGameResume?.Invoke();
        Time.timeScale = 1.0f;
    }

    public void Dispose()
    {
        onGamePause = null;
    }
}
