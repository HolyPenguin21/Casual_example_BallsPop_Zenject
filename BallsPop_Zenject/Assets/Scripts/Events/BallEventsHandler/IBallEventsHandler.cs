using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBallEventsHandler
{
    delegate void OnBallDestroyed(int value);
    delegate void OnBallDestroyedEffect(Vector3 pos);
    delegate void OnBallMissed(int value);

    public void Add_BallDestroyedListener(OnBallDestroyed method);
    public void Invoke_BallDestroyed(int value);

    public void Add_BallDestroyedEffectListener(OnBallDestroyedEffect method);
    public void Invoke_BallDestroyedEffect(Vector3 pos);

    public void Add_BallMissedListener(OnBallMissed method);
    public void Invoke_BallMissed(int value);
}
