using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class SlotDrag : MonoBehaviour
{
    bool draggable;

    private void Update()
    {
        draggable = (transform.GetComponentInParent<Slot>().sprite != null);
    }

    public void Drag()
    {
        transform.position = Input.mousePosition;
    }

    public void MouseUp()
    {
        transform.localPosition = Vector3.zero;
    }

}
