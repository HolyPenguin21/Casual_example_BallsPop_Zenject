using UnityEngine;
using UnityEngine.UI;

public class UI_PauseMenu : UI_Element
{
    Canvas pauseButton_canvas, pauseMenu_canvas;
    Button pauseButton, restartButton, resumeButton;

    IPauseHandler pauseHandler;

    public UI_PauseMenu(IPauseHandler pauseHandler, IGameStateHandler gameStateHandler)
    {
        this.pauseHandler = pauseHandler;

        pauseMenu_canvas = Get_SceneObject(pauseMenu_canvas, "PauseMenu");
        pauseButton_canvas = Get_SceneObject(pauseButton_canvas, "PauseButton");
        Setup_PauseButton();
        Setup_RestartButton(gameStateHandler);
        Setup_ResumeButton();

        Hide();
        Disable_PauseButton();

        gameStateHandler.Add_GameStartListener(Enable_PauseButton);
        gameStateHandler.Add_GameRestartListener(Hide);
        gameStateHandler.Add_GameRestartListener(Enable_PauseButton);
        gameStateHandler.Add_GameEndListener(Disable_PauseButton);

        this.pauseHandler.Add_ResumeListener(Hide);
        this.pauseHandler.Add_ResumeListener(Enable_PauseButton);
    }

    public override void Hide()
    {
        pauseMenu_canvas.gameObject.SetActive(false);
    }

    public override void Show()
    {
        pauseMenu_canvas.gameObject.SetActive(true);

        pauseHandler.Invoke_Pause();
    }

    private void OpenCloseMenu()
    {
        if (pauseMenu_canvas.gameObject.activeInHierarchy)
        {
            Hide();
            Enable_PauseButton();
        }
        else
        {
            Show();
            Disable_PauseButton();
        }
    }

    private void Setup_PauseButton()
    {
        pauseButton = Get_SceneObject(pauseButton, "Pause");
        pauseButton.onClick.AddListener(OpenCloseMenu);
    }

    private void Disable_PauseButton()
    {
        pauseButton.interactable = false;
    }

    private void Enable_PauseButton()
    {
        pauseButton.interactable = true;
    }

    private void Setup_RestartButton(IGameStateHandler gameStateHandler)
    {
        restartButton = Get_SceneObject(restartButton, "Restart");
        restartButton.onClick.AddListener(() => gameStateHandler.Invoke_GameRestart());
    }

    private void Setup_ResumeButton()
    {
        resumeButton = Get_SceneObject(resumeButton, "Resume");
        resumeButton.onClick.AddListener(pauseHandler.Invoke_Resume);
    }
}
