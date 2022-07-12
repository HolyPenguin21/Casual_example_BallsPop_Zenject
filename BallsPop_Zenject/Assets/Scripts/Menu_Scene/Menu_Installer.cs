using UnityEngine;
using Zenject;

public class Menu_Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ISceneHandler>().To<SceneHandler>().AsSingle();

        Container.Bind<UI_Main_Menu>().AsSingle().NonLazy();
        Container.Bind<UI_HighScore>().AsSingle().NonLazy();
    }
}