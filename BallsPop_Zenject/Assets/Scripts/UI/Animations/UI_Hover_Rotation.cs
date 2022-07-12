using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UI_Hover_Rotation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public enum RotationSide { left, right};
    public RotationSide rotationSide;

    public float rotationAngle = 5f;
    public float timing = 0.25f;

    Vector3 baseRotation;
    RectTransform tr;

    private void Awake()
    {
        tr = GetComponent<RectTransform>();
        baseRotation = tr.rotation.eulerAngles;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 endRotation = Vector3.zero;

        switch (rotationSide)
        {
            case RotationSide.left:
                endRotation = new Vector3(0, 0, rotationAngle);
                break;
            case RotationSide.right:
                endRotation = new Vector3(0, 0, -rotationAngle);
                break;
        }

        tr.DOLocalRotate(endRotation, timing);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tr.DOLocalRotate(baseRotation, timing);
    }

    private void OnDisable()
    {
        DOTween.Kill(tr);
    }
}
