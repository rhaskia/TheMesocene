using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class SlotDrag : MonoBehaviour
{
    Slot slot;
    RectTransform rectT;

    private void Start()
    {
        slot = transform.GetComponentInParent<Slot>();
        rectT = GetComponent<RectTransform>();
    }

    public void Drag()
    {
        transform.position = Input.mousePosition;
    }

    public void MouseUp()
    {
        //transform.localPosition = Vector3.zero;

        SlotDrag[] slots = FindObjectsOfType<SlotDrag>();

        for (int i = 0; i < slots.Length; i++)
        {
            if (GetWorldRect(rectT).Overlaps(GetWorldRect(slots[i].rectT), true) && slots[i].slot.num != 0)
                return;

            if (!slot.hotbar && slots[i].slot.hotbar)
            {
                FindObjectOfType<Info>().inven.moveToHotbar(slot.num, slots[i].slot.num);
            }

            if (slot.hotbar && !slots[i].slot.hotbar)
            {
                FindObjectOfType<Info>().inven.moveFromHotbar(slot.num, slots[i].slot.num);
            }

            if (!slot.hotbar && !slots[i].slot.hotbar)
            {
                FindObjectOfType<Info>().inven.hotbarToHotbar(slot.num, slots[i].slot.num);
            }
        }

        rectT.localPosition = Vector3.zero;
    }

    public static Rect GetWorldRect(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        // Get the bottom left corner.
        Vector3 position = corners[0];

        Vector2 size = new Vector2(
            rectTransform.lossyScale.x * rectTransform.rect.size.x,
            rectTransform.lossyScale.y * rectTransform.rect.size.y);

        return new Rect(position, size);
    }

}
