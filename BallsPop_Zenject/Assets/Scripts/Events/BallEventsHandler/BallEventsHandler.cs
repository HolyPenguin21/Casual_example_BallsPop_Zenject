using System;
using UnityEngine;

public class BallEventsHandler : IBallEventsHandler, IDisposable
{
    event IBallEventsHandler.OnBallDestroyed onBallDestroyed;
    event IBallEventsHandler.OnBallDestroyedEffect onBallDestroyedEffect;
    event IBallEventsHandler.OnBallMissed onBallMissed;
    public void Add_BallDestroyedListener(IBallEventsHandler.OnBallDestroyed method)
    {
        onBallDestroyed += method;
    }

    public void Add_BallDestroyedEffectListener(IBallEventsHandler.OnBallDestroyedEffect method)
    {
        onBallDestroyedEffect += method;
    }

    public void Add_BallMissedListener(IBallEventsHandler.OnBallMissed method)
    {
        onBallMissed += method;
    }

    public void Invoke_BallDestroyed(int value)
    {
        onBallDestroyed?.Invoke(value);
    }

    public void Invoke_BallDestroyedEffect(Vector3 pos)
    {
        onBallDestroyedEffect?.Invoke(pos);
    }

    public void Invoke_BallMissed(int value)
    {
        onBallMissed?.Invoke(value);
    }

    public void Dispose()
    {
        onBallDestroyed = null;
        onBallDestroyedEffect = null;
        onBallMissed = null;
    }
}
