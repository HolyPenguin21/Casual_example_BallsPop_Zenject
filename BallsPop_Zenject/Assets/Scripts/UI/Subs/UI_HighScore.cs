using UnityEngine;
using UnityEngine.UI;

public class UI_HighScore : UI_Element
{
    Canvas highScore_canvas;
    Text score_text;

    public UI_HighScore()
    {
        highScore_canvas = Get_SceneObject(highScore_canvas, "HighScore_Canvas");
        score_text = Get_SceneObject(score_text, "Score_Text");

        Update_HighScoreText();
    }

    public void Update_HighScoreText()
    {
        score_text.text = "Current high score :\n" + PlayerPrefs.GetInt("highScore");
    }

    public override void Hide()
    {
        highScore_canvas.gameObject.SetActive(false);
    }

    public override void Show()
    {
        highScore_canvas.gameObject.SetActive(true);
    }
}
