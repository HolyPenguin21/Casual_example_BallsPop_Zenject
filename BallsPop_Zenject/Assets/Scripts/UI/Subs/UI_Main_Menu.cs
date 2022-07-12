using UnityEngine;
using UnityEngine.UI;

public class UI_Main_Menu : UI_Element
{
    Canvas mainMenu_canvas;
    Button startGame_button, quitGame_buton;

    public UI_Main_Menu(ISceneHandler sceneHandler)
    {
        mainMenu_canvas = Set_CanvasObject();
        Setup_StartButton(sceneHandler);
        Setup_QuitButton(sceneHandler);
    }

    private void Setup_StartButton(ISceneHandler sceneHandler)
    {
        startGame_button = Get_SceneObject(startGame_button, "StartGame");
        startGame_button.onClick.AddListener(() => sceneHandler.Load_GameScene());
    }

    private void Setup_QuitButton(ISceneHandler sceneHandler)
    {
        quitGame_buton = Get_SceneObject(quitGame_buton, "Quit");
        quitGame_buton.onClick.AddListener(() => sceneHandler.QuitGame());
    }

    protected override Canvas Set_CanvasObject()
    {
        Canvas canvas = Get_SceneObject(mainMenu_canvas, "MainMenu");
        return canvas;
    }

    public override void Hide()
    {
        mainMenu_canvas.gameObject.SetActive(false);
    }

    public override void Show()
    {
        mainMenu_canvas.gameObject.SetActive(true);
    }
}
