using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LifesPanel : UI_Element
{
    GameObject canvas_obj;
    GameObject[] lifes_obj;

    Player player;

    public UI_LifesPanel(EventsHandler eventsHandler, Player player)
    {
        this.player = player;

        canvas_obj = Get_SceneObject(canvas_obj, "Lifes");

        eventsHandler.onGameStart += Set_MaxLifes;
        eventsHandler.onGameRestart += Set_MaxLifes;
        eventsHandler.onBallMissed += RemoveLife;

        Set_LifesObjects();
    }

    public override void Hide()
    {
        canvas_obj.SetActive(false);
    }

    public override void Show()
    {
        canvas_obj.SetActive(true);
    }

    private void Set_LifesObjects()
    {
        lifes_obj = new GameObject[3];

        for (int i = 0; i < canvas_obj.transform.childCount; i++)
            lifes_obj[i] = canvas_obj.transform.GetChild(i).gameObject;
    }

    private void RemoveLife(int value)
    {
        for (int i = 0; i < value; i++)
        {
            lifes_obj[player.CurHealth].SetActive(false);
        }
    }

    private void Set_MaxLifes()
    {
        foreach (GameObject life_obj in lifes_obj)
            life_obj.SetActive(true);
    }
}
