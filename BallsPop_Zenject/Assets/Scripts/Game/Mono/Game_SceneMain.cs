using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_SceneMain : MonoBehaviour
{
    SceneSettings sceneSettings;
    SceneLoader sceneLoader;
    EventsHandler eventsHandler;
    UI_Controller uIController;
    SpawnController spawnController;    
    Player player;
    ScoreManager scoreManager;  

    private void Awake()
    {
        sceneSettings = new SceneSettings(Camera.main);
        sceneLoader = new SceneLoader();
        eventsHandler = new EventsHandler();

        player = new Player(eventsHandler);

        uIController = new UI_Controller();
        spawnController = new SpawnController(sceneSettings, eventsHandler, 0.5f, 100f);
        scoreManager = new ScoreManager(eventsHandler, player);

        eventsHandler.onGameStart += StartGame;
        eventsHandler.onGameEnd += EndGame;
        eventsHandler.onGameRestart += EndGame;
        eventsHandler.onGameRestart += StartGame;
    }

    private void Start()
    {
        uIController.Prepare_GameSceneUI(sceneLoader, eventsHandler, player);
    }

    private void Update()
    {
        spawnController.MakeItHarder();
    }

    private void StartGame()
    {
        spawnController.SpawnEnabled = true;
        StartCoroutine(spawnController.SpawnBall());
    }

    private void EndGame()
    {
        StopAllCoroutines();

        spawnController.SpawnEnabled = false;
        spawnController.Reset_ActiveElements();
        spawnController.Reset_SpawnVars();
    }    

    private void OnDestroy()
    {
        StopAllCoroutines();

        eventsHandler.RemoveSubscribtions();
    }
}
