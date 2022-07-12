using UnityEngine;
using UnityEngine.UI;

public class UI_HighScore : UI_Element
{
    Canvas highScore_canvas;
    Text score_text;

    public UI_HighScore()
    {
        highScore_canvas = Set_CanvasObject();
        score_text = Get_SceneObject(score_text, "Score_Text");

        Show_HighScore();
    }

    public void Show_HighScore()
    {
        score_text.text = "Current high score :\n" + PlayerPrefs.GetInt("highScore");
    }

    public override void Hide()
    {
        throw new System.NotImplementedException();
    }

    public override void Show()
    {
        throw new System.NotImplementedException();
    }

    protected override Canvas Set_CanvasObject()
    {
        Canvas canvas = Get_SceneObject(highScore_canvas, "HighScore_Canvas");
        return canvas;
    }
}
