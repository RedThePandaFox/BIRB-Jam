using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableCard : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public CardSCOB card;
    Transform originalParent, newParent;
    Canvas canvas;

    void Start()
    {
        originalParent = transform.parent;
        canvas = originalParent.parent.GetComponent<Canvas>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(Hand.canPlayCards)
        {
        transform.parent = canvas.transform;

        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition, canvas.worldCamera,
            out movePos);

        Vector3 mousePos = canvas.transform.TransformPoint(movePos);
        transform.position = mousePos;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        CheckSlotCollision(results);
    }

    void CheckSlotCollision(List<RaycastResult> results)
    {
        foreach (var result in results)
        {
            if(result.gameObject.name.Contains("Line"))
            {
                originalParent = result.gameObject.transform;
                break;
            }
        }
        transform.parent = originalParent;
    }
}
