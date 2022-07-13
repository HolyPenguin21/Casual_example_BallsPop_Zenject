using UnityEngine;
using DG.Tweening;

public class Movement
{
    public void StartMove(Transform tr)
    {
        tr.DOMoveY(-10, 10f);
    }
}
