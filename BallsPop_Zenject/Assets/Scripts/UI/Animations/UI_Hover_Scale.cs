using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UI_Hover_Scale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    RectTransform tr;
    Vector3 baseScale;

    public float scaleValue = 1.25f;
    public float timing = 0.25f;

    private void Awake()
    {
        tr = GetComponent<RectTransform>();
        baseScale = tr.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tr.DOScale(scaleValue, timing);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tr.DOScale(baseScale, timing);
    }

    private void OnDisable()
    {
        DOTween.Kill(tr);
    }
}
