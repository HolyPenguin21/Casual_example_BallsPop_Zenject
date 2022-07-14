using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpawnFactory : MonoBehaviour
{
    ISceneSettings sceneSettings;
    IBallEventsHandler ballEventsHandler;

    BallCreator ballCreator;
    ParticlesCreator particlesCreator;

    bool spawnEnabled = false;
    float current_spawnRate = 0.5f;
    [SerializeField] float start_spawnRate = 0.5f;
    [SerializeField] float spawnDelta = 100f;

    [Inject]
    public void Init(ISceneSettings sceneSettings, IBallEventsHandler ballEventsHandler, IGameStateHandler gameStateHandler)
    {
        this.sceneSettings = sceneSettings;
        this.ballEventsHandler = ballEventsHandler;

        gameStateHandler.Add_GameStartListener(Enable_Spawn);
        gameStateHandler.Add_GameEndListener(Disable_Spawn);

        gameStateHandler.Add_GameRestartListener(Disable_Spawn);
        gameStateHandler.Add_GameRestartListener(Enable_Spawn);

        ballEventsHandler.Add_BallDestroyedEffectListener(SpawnParticle);
    }

    private void Awake()
    {
        ballCreator = new BallCreator(sceneSettings, ballEventsHandler);
        particlesCreator = new ParticlesCreator();
    }

    void Update()
    {
        MakeItHarder();
    }

    private IEnumerator SpawnBall()
    {
        while (spawnEnabled)
        {
            ballCreator.SpawnObject();
            yield return new WaitForSeconds(current_spawnRate);
        }
    }

    private void SpawnParticle(Vector3 pos)
    {
        particlesCreator.SpawnObject(pos);
    }

    private void MakeItHarder()
    {
        if (!spawnEnabled) return;

        current_spawnRate -= Time.deltaTime / spawnDelta;
    }

    private void Enable_Spawn()
    {
        spawnEnabled = true;
        StartCoroutine(SpawnBall());
    }

    private void Disable_Spawn()
    {
        spawnEnabled = false;
        StopAllCoroutines();

        Reset_SpawnVars();
        Reset_ActiveElements();
    }

    private void Reset_SpawnVars()
    {
        current_spawnRate = start_spawnRate;
    }

    private void Reset_ActiveElements()
    {
        ballCreator.Reset_ActiveBalls();
        particlesCreator.Reset_ActiveParticles();
    }
}
