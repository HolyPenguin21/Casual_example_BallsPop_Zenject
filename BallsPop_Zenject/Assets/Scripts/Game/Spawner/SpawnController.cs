using System.Collections;
using UnityEngine;

public class SpawnController
{    
    BallsCreator ballsCreator;
    ParticleCreator particleCreator;

    private bool spawnEnabled = false;
    public bool SpawnEnabled 
    { 
        set { spawnEnabled = value; } 
    }

    float spawnRate = 0.5f;
    float start_spawnRate = 0.5f;
    float spawnDelta = 100f;

    public SpawnController(SceneSettings sceneSettings, EventsHandler eventsHandler, float start_spawnRate, float spawnDelta)
    {
        this.spawnDelta = spawnDelta;
        this.start_spawnRate = start_spawnRate;
        spawnRate = this.start_spawnRate;

        ballsCreator = new BallsCreator(sceneSettings, eventsHandler);
        particleCreator = new ParticleCreator();

        eventsHandler.onBallDestroyedEffect += SpawnParticle;
    }

    public IEnumerator SpawnBall()
    {
        while (spawnEnabled)
        {
            ballsCreator.SpawnObject();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void SpawnParticle(Vector3 pos)
    {
        particleCreator.SpawnObject(pos);
    }

    public void MakeItHarder()
    {
        if (!spawnEnabled) return;

        spawnRate -= Time.deltaTime / spawnDelta;
    }

    public void Reset_SpawnVars()
    {
        spawnRate = start_spawnRate;
    }

    public void Reset_ActiveElements()
    {
        ballsCreator.Reset_ActiveBalls();
        particleCreator.Reset_ActiveParticles();
    }
}
