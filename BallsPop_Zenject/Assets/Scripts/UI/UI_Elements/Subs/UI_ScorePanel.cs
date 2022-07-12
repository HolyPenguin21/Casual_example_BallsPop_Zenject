using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ScorePanel : UI_Element
{
    GameObject canvas_obj;
    Text score_text;

    public UI_ScorePanel()
    { 
        canvas_obj = Get_SceneObject(canvas_obj, "ScoreCanvas");
        score_text = Get_SceneObject(score_text, "ScoreText");
    }

    public void Update_ScoreText(int value)
    {
        score_text.text = "Score : " + value;
    }

    public void Show_HighScore()
    {
        score_text.text = "Current high score :\n" + PlayerPrefs.GetInt("highScore");
    }

    public override void Hide()
    {
        canvas_obj.SetActive(false);
    }

    public override void Show()
    {
        canvas_obj.SetActive(true);
    }
}
