using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemStack
{
    public ItemStack(Item i, int a)
    {
        this.item = i;
        this.amount = a;
    }

    public Item item;
    public int amount;

    internal static ItemStack empty = new ItemStack(null, 0);
}

public class Inventory : MonoBehaviour
{
    public ItemStack[] hotbar = new ItemStack[11];
    public ItemStack[] inventory = new ItemStack[44];

    public Image[] hotbarI;
    public Image[] inventoryI;

    public Item it;

    public Slot draggedSlot;
    public Slot underMouse;
    Slot[] allSlots;
    public int slotWidth;

    public Sprite empty;

    Vector2 canvasSize;

    // Start is called before the first frame update
    void Start()
    {
        canvasSize = FindObjectOfType<Canvas>().pixelRect.size;

        allSlots = FindObjectsOfType<Slot>();
        inventory = Enumerable.Repeat<ItemStack>(ItemStack.empty, 44).ToArray();
        inventory[0] = new ItemStack(it, 10);
        hotbar = Enumerable.Repeat<ItemStack>(ItemStack.empty, 11).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hotbar.Length; i++)
        {
            if (hotbar[i].item != null)
                hotbarI[i].sprite = hotbar[i].item.sprite;
            else
                inventoryI[i].sprite = empty;
        }

        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].item != null)
                inventoryI[i].sprite = inventory[i].item.sprite;
            else
                inventoryI[i].sprite = empty;
        }

        if (underMouse == null) underMouse = GetSlot((Vector2)(Input.mousePosition * 2) - canvasSize);
    }

    public (ItemStack, ItemStack) SwapSlots(ItemStack i, ItemStack j)
    {
        return (j, i);
    }

    public Slot GetSlot(Vector2 pos)
    {
        print(allSlots[2].transform.position + "  / " + pos);
        for (int i = 0; i < allSlots.Length; i++)
        {
            Vector2 slot = allSlots[i].transform.position;

            if (!(slot.x + (slotWidth / 2) > pos.x && slot.x - (slotWidth / 2) < pos.x &&
                slot.y + (slotWidth / 2) > pos.y && slot.y - (slotWidth / 2) < pos.y))
                break;

            if (allSlots[i] == draggedSlot)
                break;

            return allSlots[i];

        }

        return null;
    }

}
