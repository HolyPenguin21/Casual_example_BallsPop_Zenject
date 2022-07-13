using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ContinuousRotation
{
    public void StartRotation(Transform tr)
    {
        Vector3 endRotation = new Vector3(tr.rotation.x + 180, tr.rotation.y + 180, tr.rotation.z + 180);

        tr.DOLocalRotate(endRotation, 2f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }
}
