using UnityEngine;
using UnityEngine.UI;

public class UI_Healthbar : UI_Element
{
    GameObject canvas_obj;
    GameObject[] lifes_obj;

    IPlayer player;

    public UI_Healthbar(IGameStateHandler gameStateHandler, IBallEventsHandler ballEventsHandler, IPlayer player)
    {
        this.player = player;

        canvas_obj = Get_SceneObject(canvas_obj, "Lifes");

        gameStateHandler.Add_GameStartListener(Set_MaxLifes);
        gameStateHandler.Add_GameRestartListener(Set_MaxLifes);
        ballEventsHandler.Add_BallMissedListener(RemoveLife);

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
            lifes_obj[player.Get_CurrentHealth()].SetActive(false);
        }
    }

    private void Set_MaxLifes()
    {
        foreach (GameObject life_obj in lifes_obj)
            life_obj.SetActive(true);
    }
}
