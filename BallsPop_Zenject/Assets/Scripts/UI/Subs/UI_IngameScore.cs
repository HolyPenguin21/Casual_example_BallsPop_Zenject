using UnityEngine;
using UnityEngine.UI;

public class UI_IngameScore : UI_Element
{
    Canvas score_canvas;
    Text score_text;

    IPlayer player;

    public UI_IngameScore(IBallEventsHandler ballEventsHandler, IPlayer player)
    {
        this.player = player;

        score_canvas = Get_SceneObject(score_canvas, "ScoreCanvas");
        score_text = Get_SceneObject(score_text, "ScoreText");

        ballEventsHandler.Add_BallDestroyedListener(Update_ScoreText);
        ballEventsHandler.Add_BallMissedListener(Update_ScoreText);

        Update_ScoreText(0);
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
}
