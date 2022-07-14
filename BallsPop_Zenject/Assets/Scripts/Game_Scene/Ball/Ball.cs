using UnityEngine;
using Zenject;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    private GameObject go;
    public GameObject Go
    {
        get { return go; }
    }
    private Transform tr;
    public Transform Tr
    {
        get { return tr; }
    }
    Transform mesh_tr;

    [SerializeField] private int scorePointsReward = 1;
    public int ScorePointsReward
    {
        get { return scorePointsReward; }
    }

    ContinuousRotation continuousRotation;
    Movement movement;

    IBallEventsHandler ballEventsHandler;

    private void Awake()
    {
        go = gameObject;
        tr = transform;
        mesh_tr = tr.Find("Mesh");

        continuousRotation = new ContinuousRotation();
        movement = new Movement();
    }

    public void Init(IBallEventsHandler ballEventsHandler)
    {
        this.ballEventsHandler = ballEventsHandler;
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
        if (Time.timeScale == 0.0f) return;

        go.SetActive(false);
        ballEventsHandler.Invoke_BallDestroyed(scorePointsReward);
        ballEventsHandler.Invoke_BallDestroyedEffect(tr.position);
    }

    public void OnTriggerEnter(Collider other)
    {
        go.SetActive(false);
        ballEventsHandler.Invoke_BallMissed(scorePointsReward);
    }
}
