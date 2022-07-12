using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StartGame : UI_Element
{
    GameObject canvas_obj;
    Button startButton;

    public UI_StartGame(EventsHandler eventsHandler)
    {
        Set_CanvasObject(Get_SceneObject(canvas_obj, "GameStart"));
        Set_StartButton(Get_SceneObject(startButton, "Start"), eventsHandler);

        eventsHandler.onGameStart += Hide;
        eventsHandler.onGameEnd += Show;
    }

    private void Set_CanvasObject(GameObject obj)
    {
        canvas_obj = obj;

        if (canvas_obj == null)
        {
            canvas_obj = MonoBehaviour.Instantiate(Resources.Load("UI/GameStart_Canvas", typeof(GameObject))) as GameObject;
        }
    }

    private void Set_StartButton(Button button, EventsHandler eventsHandler)
    {
        startButton = button;
        startButton.onClick.AddListener(() => eventsHandler.On_GameStart());
    }

    public override void Hide()
    {
        canvas_obj.SetActive(false);
    }

    public override void Show()
    {
        canvas_obj.SetActive(true);
    }
}
