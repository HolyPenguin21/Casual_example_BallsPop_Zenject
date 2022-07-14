using UnityEngine;
using UnityEngine.UI;

public class UI_IngameScore : UI_Element
{
    Canvas score_canvas;
    Text score_text;

    IPlayer player;

    public UI_IngameScore(IGameStateHandler gameStateHandler, IBallEventsHandler ballEventsHandler, IPlayer player)
    {
        this.player = player;

        score_canvas = Get_SceneObject(score_canvas, "ScoreCanvas");
        score_text = Get_SceneObject(score_text, "ScoreText");

        gameStateHandler.Add_GameStartListener(Reset_ScoreText);
        gameStateHandler.Add_GameRestartListener(Reset_ScoreText);
        ballEventsHandler.Add_BallDestroyedListener(Update_ScoreText);
        ballEventsHandler.Add_BallMissedListener(Update_ScoreText);

        Reset_ScoreText();
    }

    public override void Hide()
    {
        score_canvas.gameObject.SetActive(false);
    }

    public override void Show()
    {
        score_canvas.gameObject.SetActive(true);
    }

    private void Update_ScoreText(int value)
    {
        score_text.text = "Score : " + player.Get_CurrentScore();
    }

    private void Reset_ScoreText()
    {
        score_text.text = "Score : " + 0;
    }
}
