using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Start : UI_Element
{
    Canvas start_canvas;
    Button startButton;

    public UI_Start(IGameStateHandler gameStateHandler)
    {
        start_canvas = Get_SceneObject(start_canvas, "GameStart");
        Setup_StartButton(gameStateHandler);

        gameStateHandler.Add_GameStartListener(Hide);
        gameStateHandler.Add_GameEndListener(Show);
    }

    public override void Hide()
    {
        start_canvas.gameObject.SetActive(false);
    }

    public override void Show()
    {
        start_canvas.gameObject.SetActive(true);
    }

    private void Setup_StartButton(IGameStateHandler gameStateHandler)
    {
        startButton = Get_SceneObject(startButton, "Start");
        startButton.onClick.AddListener(() => gameStateHandler.Invoke_GameStart());
    }
}
