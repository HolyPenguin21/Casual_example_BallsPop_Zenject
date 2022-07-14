using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : ISceneHandler
{
    public void Load_GameScene()
    {
        Load_Scene(1);
    }

    public void Load_MainMenuScene()
    {
        Load_Scene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Load_Scene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
