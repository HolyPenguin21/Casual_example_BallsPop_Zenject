using UnityEngine;

public class Menu_SceneMain : MonoBehaviour
{
    SceneLoader sceneLoader;
    UI_Controller uIController;

    private void Awake()
    {
        sceneLoader = new SceneLoader();
        uIController = new UI_Controller();
    }

    private void Start()
    {
        uIController.Prepare_MenuSceneUI(sceneLoader);
    }
}
