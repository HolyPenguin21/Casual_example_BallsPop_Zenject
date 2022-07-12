using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller
{
    UI_Menu_Main menu_Main;
    UI_BurgerMenu burger;
    UI_PauseMenu pause;
    UI_StartGame startGame;
    UI_ScorePanel scorePanel;
    UI_LifesPanel lifesPanel;

    Player player;

    public void Prepare_MenuSceneUI(SceneLoader sceneLoader)
    {
        menu_Main = new UI_Menu_Main(sceneLoader);
        scorePanel = new UI_ScorePanel();

        scorePanel.Show_HighScore();
    }

    public void Prepare_GameSceneUI(SceneLoader sceneLoader, EventsHandler eventsHandler, Player player)
    {
        this.player = player;

        burger = new UI_BurgerMenu(sceneLoader);
        pause = new UI_PauseMenu(eventsHandler);
        startGame = new UI_StartGame(eventsHandler);
        scorePanel = new UI_ScorePanel();
        lifesPanel = new UI_LifesPanel(eventsHandler, player);

        eventsHandler.onGameStart += Update_ScoreText;
        eventsHandler.onScoreUpdate += Update_ScoreText;
        eventsHandler.onGameRestart += Update_ScoreText;

        Update_ScoreText();
    }

    private void Update_ScoreText()
    {
        scorePanel.Update_ScoreText(player.CurrentScore);
    }
}
