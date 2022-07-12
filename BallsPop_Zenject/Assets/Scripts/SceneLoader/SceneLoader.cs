using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public void Load_MenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void Load_GameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void Load_Scene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
