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
        Debug.Log("Event > Pause");
    }

    public void Add_ResumeListener(IPauseHandler.OnGameResume method)
    {
        onGameResume += method;
    }

    public void Invoke_Resume()
    {
        onGameResume?.Invoke();
        Debug.Log("Event > onGameResume");
    }

    public void Dispose()
    {
        onGamePause = null;
    }
}
