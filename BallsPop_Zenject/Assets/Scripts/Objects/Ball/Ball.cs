using UnityEngine;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    private GameObject go;
    private Transform tr;
    Transform mesh_tr;

    private int scorePointsReward = 1;

    ContinuousRotation continuousRotation;
    Movement movement;

    EventsHandler eventsHandler;

    public int ScorePointsReward
    {
        get { return scorePointsReward; }
    }

    public GameObject Go
    {
        get { return go; }
    }

    public Transform Tr
    {
        get { return tr; }
    }

    private void Awake()
    {
        go = gameObject;
        tr = transform;
        mesh_tr = tr.Find("Mesh");

        continuousRotation = new ContinuousRotation();
        movement = new Movement();
    }

    public void Init(EventsHandler eventsHandler, int scorePointsReward)
    {
        this.eventsHandler = eventsHandler;
        this.scorePointsReward = scorePointsReward;
    }

    private void OnEnable()
    {
        continuousRotation.StartRotation(mesh_tr);
        movement.StartMove(tr);
    }

    private void OnDisable()
    {
        DOTween.Kill(tr);
        DOTween.Kill(mesh_tr);
    }

    private void OnMouseDown()
    {
        if (Time.timeScale == 0) return;

        go.SetActive(false);
        eventsHandler.On_BallDestroyed(scorePointsReward);
        eventsHandler.On_BallDestroyedEffect(tr.position);
    }

    public void OnTriggerEnter(Collider other)
    {
        go.SetActive(false);
        eventsHandler.On_BallMissed(scorePointsReward);
    }
}
