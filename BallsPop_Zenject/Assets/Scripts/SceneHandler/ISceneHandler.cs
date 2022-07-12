using UnityEngine;
using System.Collections;

public interface ISceneHandler
{
    public void Load_MainMenuScene();
    public void Load_GameScene();
    public void QuitGame();
}
