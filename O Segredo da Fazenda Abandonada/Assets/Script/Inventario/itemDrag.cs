using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class itemDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    Transform originalParent;
    CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; // Move the item to the current mouse position
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        Slot newslot = eventData.pointerEnter?.GetComponent<Slot>();
        Slot oldslot = originalParent.GetComponent<Slot>();

        if(newslot != null)
        {
            if(newslot.itemSlot != null)
            {
                newslot.itemSlot.transform.SetParent(oldslot.transform);
                oldslot.itemSlot = newslot.itemSlot;
                newslot.itemSlot.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Reset position to the center of the new parent
            }
            else
            {
                oldslot.itemSlot = null;
            }
            transform.SetParent(newslot.transform);
            newslot.itemSlot = gameObject;
        }
        else
        {
            transform.SetParent(originalParent);
        }
        GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Reset position to the center of the new parent
    }

}
