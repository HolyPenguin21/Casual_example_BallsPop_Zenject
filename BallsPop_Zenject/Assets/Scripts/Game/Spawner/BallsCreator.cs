using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsCreator
{
    GameObject prefab;

    Ball[] ballsPool;
    Transform poolHolder;

    ViewportBounds viewportBounds;

    public BallsCreator(SceneSettings sceneSettings, EventsHandler eventsHandler)
    {
        prefab = Resources.Load("Objects/BallPrefab", typeof(GameObject)) as GameObject;

        viewportBounds = sceneSettings.Get_ViewportBounds();

        PreparePool(50, eventsHandler);
    }    

    public void SpawnObject()
    {
        Ball ball = Get_FreeBall();
        ball.Tr.position = Set_SpawnPosition();
        ball.Tr.rotation = Set_RandomRotation();

        ball.Go.SetActive(true);
    }

    public void PreparePool(int count, EventsHandler eventsHandler)
    {
        ballsPool = new Ball[count];
        poolHolder = new GameObject("PoolHolder_Balls").transform;

        for (int i = 0; i < ballsPool.Length; i++)
        {
            GameObject ball_obj = MonoBehaviour.Instantiate(prefab, poolHolder);
            ball_obj.SetActive(false);

            Ball ball_sc = ball_obj.GetComponent<Ball>();
            ball_sc.Init(eventsHandler, 1);

            ballsPool[i] = ball_sc;
        }
    }

    private Ball Get_FreeBall()
    {
        foreach (Ball ball in ballsPool)
        {
            if (!ball.Go.activeInHierarchy)
                return ball;
        }

        Debug.LogError("Missing ball prefabs, add more into pool");
        return null;
    }

    private Vector3 Set_SpawnPosition()
    {
        float x_Scale = 1; // Review - give reference

        float x_Pos = Random.Range(-viewportBounds.x_bounds[1] + x_Scale, viewportBounds.x_bounds[1] - x_Scale);
        float y_Pos = viewportBounds.y_bounds[1];

        Vector3 pos = new Vector3(x_Pos, y_Pos, 0);

        return pos;
    }

    private Quaternion Set_RandomRotation()
    {
        return Quaternion.identity;
    }

    public void Reset_ActiveBalls()
    {
        for (int i = 0; i < ballsPool.Length; i++)
        {
            Ball ball = ballsPool[i];
            if (ball.Go.activeInHierarchy)
                ball.Go.SetActive(false);
        }
    }
}
