using UnityEngine;
using UnityEngine.UI;

public class UI_BurgerMenu : UI_Element
{
    GameObject burgerButtonCanvas_obj, menuCanvas_obj;
    Button burgerButton, quitToMenu_button, quitGame_button;

    public UI_BurgerMenu(SceneLoader sceneLoader)
    {
        Set_BurgerButtonObject(Get_SceneObject(burgerButtonCanvas_obj, "BurgerButton"));
        Set_BurgerButton(Get_SceneObject(burgerButton, "Burger"));

        Set_BurgerMenuObject(Get_SceneObject(menuCanvas_obj, "BurgerMenu"));
        Set_QuitToMenuButton(Get_SceneObject(quitToMenu_button, "QuitToMenu"), sceneLoader);
        Set_QuitGameButton(Get_SceneObject(quitGame_button, "QuitGame"), sceneLoader);

        Hide();
    }

    #region Menu actions
    private void OpenCloseMenu()
    {
        if (menuCanvas_obj.activeInHierarchy)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    public override void Hide()
    {
        menuCanvas_obj.SetActive(false);
    }

    public override void Show()
    {
        menuCanvas_obj.SetActive(true);
    }
    #endregion

    #region Setup

    #region Burger button
    public void Set_BurgerButtonObject(GameObject obj)
    {
        burgerButtonCanvas_obj = obj;

        if (burgerButtonCanvas_obj == null)
        {
            burgerButtonCanvas_obj = MonoBehaviour.Instantiate(Resources.Load("UI/BurgerMenu/BurgerButton_Canvas", typeof(GameObject))) as GameObject;
        }
    }

    public void Set_BurgerButton(Button button)
    {
        burgerButton = button;
        burgerButton.onClick.AddListener(OpenCloseMenu);
    }
    #endregion

    #region Burger menu
    public void Set_BurgerMenuObject(GameObject obj)
    {
        menuCanvas_obj = obj;

        if (menuCanvas_obj == null)
        {
            menuCanvas_obj = MonoBehaviour.Instantiate(Resources.Load("UI/BurgerMenu/BurgerMenu_Canvas", typeof(GameObject))) as GameObject;
        }
    }

    public void Set_QuitToMenuButton(Button button, SceneLoader sceneLoader)
    {
        quitToMenu_button = button;
        quitToMenu_button.onClick.AddListener(() => sceneLoader.Load_Scene(0));
    }

    public void Set_QuitGameButton(Button button, SceneLoader sceneLoader)
    {
        quitGame_button = button;
        quitGame_button.onClick.AddListener(sceneLoader.QuitGame);
    }
    #endregion

    #endregion
}
