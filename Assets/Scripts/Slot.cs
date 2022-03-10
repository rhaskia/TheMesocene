using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    Inventory inven;
    public int num;
    public bool hotbar;
    bool draggable;
    Vector3 lp;

    private void Start()
    {
        inven = FindObjectOfType<Inventory>();
        lp = transform.position;
    }

    private void Update()
    {
        if (hotbar) draggable = (inven.hotbar[num].amount != 0);
        else draggable = (inven.inventory[num].amount != 0);
    }

    public void MouseEnter()
    {
        print("hehe haha");
        //if (inven.draggedSlot != this) FindObjectOfType<Inventory>().underMouse = this;
    }

    public void MouseExit()
    {
        //if (inven.underMouse == this) FindObjectOfType<Inventory>().underMouse = null;
    }

    public void MouseDown()
    {
        if (draggable)
        {
            inven.draggedSlot = this;
            FindObjectOfType<Inventory>().underMouse = null;
        }
    }

    public void MouseUp()
    {
        if (inven.draggedSlot == this && inven.underMouse != null)
        {
            var dragged = inven.inventory[num];
            var mouse = inven.inventory[inven.underMouse.num];

            print(num + "      " + inven.underMouse.num);

            if (mouse.item == null)
            {
                print("");
                mouse = new ItemStack(dragged.item, dragged.amount);
                dragged = ItemStack.empty;
            }

            inven.inventory[num] = dragged;
            inven.inventory[inven.underMouse.num] = mouse;

            inven.draggedSlot = null;

        }

        transform.position = lp;
    }

    public void MouseDrag()
    {
        if (draggable) { transform.position = Input.mousePosition; inven.draggedSlot = this; }
    }
}
