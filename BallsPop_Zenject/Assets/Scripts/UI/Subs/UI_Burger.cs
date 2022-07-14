using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Burger : UI_Element
{
    Canvas burgerButton_canvas, burgerMenu_canvas;
    Button burgerButton, menuButton, quitButton;

    public UI_Burger(ISceneHandler sceneHandler)
    {
        burgerButton_canvas = Get_SceneObject(burgerButton_canvas, "BurgerButton");
        burgerMenu_canvas = Get_SceneObject(burgerMenu_canvas, "BurgerMenu");

        Setup_BurgerButton();
        Setup_BackToMenuButton(sceneHandler);
        Setup_QuitButton(sceneHandler);

        Hide();
    }

    public override void Hide()
    {
        burgerMenu_canvas.gameObject.SetActive(false);
    }

    public override void Show()
    {
        burgerMenu_canvas.gameObject.SetActive(true);
    }

    private void OpenCloseMenu()
    {
        if (burgerMenu_canvas.gameObject.activeInHierarchy)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Setup_BurgerButton()
    {
        burgerButton = Get_SceneObject(burgerButton, "Burger");
        burgerButton.onClick.AddListener(OpenCloseMenu);
    }

    private void Setup_BackToMenuButton(ISceneHandler sceneHandler)
    {
        menuButton = Get_SceneObject(menuButton, "QuitToMenu");
        menuButton.onClick.AddListener(sceneHandler.Load_MainMenuScene);
    }

    private void Setup_QuitButton(ISceneHandler sceneHandler)
    {
        quitButton = Get_SceneObject(quitButton, "QuitGame");
        quitButton.onClick.AddListener(sceneHandler.QuitGame);
    }
}
