using UnityEngine;
using Zenject;

public class Game_Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ISceneHandler>().To<SceneHandler>().AsSingle();
        Container.Bind<IPauseHandler>().To<PauseHandler>().AsSingle();
        Container.Bind<IGameStateHandler>().To<GameStateHandler>().AsSingle();
        Container.Bind<IBallEventsHandler>().To<BallEventsHandler>().AsSingle();
        Container.Bind<IPlayer>().To<Player>().AsSingle();
        Container.Bind<ISceneSettings>().To<SceneSettings>().AsSingle();

        Container.Bind<UI_Start>().AsSingle().NonLazy();
        Container.Bind<UI_PauseMenu>().AsSingle().NonLazy();
        Container.Bind<UI_Burger>().AsSingle().NonLazy();
        Container.Bind<UI_IngameScore>().AsSingle().NonLazy();
    }
}