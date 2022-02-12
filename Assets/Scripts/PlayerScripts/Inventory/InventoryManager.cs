using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    Info info;

    public List<Item> items;
    public List<int> itemAmounts;

    public List<Item> hotbar;
    public List<int> hotbarAmounts;

    // Start is called before the first frame update
    private void Start()
    {
        moveFromHotbar(0, 9);
    }

    // Update is called once per frame
    void Update()
    {
        CleanInventory();
    }

    void CleanInventory()
    {
        for (int i = 0; i < items.Count - 1; i++)
        {
            if (items[i] == null && items[i + 1] != null)
            {
                items[i] = items[i + 1];
                itemAmounts[i] = itemAmounts[i + 1];

                items[i + 1] = null;
                itemAmounts[i + 1] = 0;
            }
        }
    }

    public void moveToHotbar(int num, int hotbarNum)
    {
        if (hotbar[hotbarNum] != null)
        {
            Item temp = hotbar[hotbarNum];
            int tempInt = hotbarAmounts[hotbarNum];

            hotbar[hotbarNum] = items[num];
            hotbarAmounts[hotbarNum] = itemAmounts[num];

            items[num] = temp;
            itemAmounts[num] = tempInt;

            print("b");
        }

        if (hotbar[hotbarNum] == null)
        {
            hotbar[hotbarNum] = items[num];
            hotbarAmounts[hotbarNum] = itemAmounts[num];

            items[num] = null;
            itemAmounts[num] = 0;

        }
    }

    public void hotbarToHotbar(int num, int hotbarNum)
    {
        if (hotbar[hotbarNum] != null)
        {
            Item temp = hotbar[hotbarNum];
            int tempInt = hotbarAmounts[hotbarNum];

            hotbar[hotbarNum] = hotbar[num];
            hotbarAmounts[hotbarNum] = hotbarAmounts[num];

            hotbar[num] = temp;
            hotbarAmounts[num] = tempInt;
        }

        if (hotbar[hotbarNum] == null)
        {
            hotbar[hotbarNum] = hotbar[num];
            hotbarAmounts[hotbarNum] = hotbarAmounts[num];

            hotbar[num] = null;
            hotbarAmounts[num] = 0;

        }
    }

    public void moveFromHotbar(int num, int hotbarNum)
    {
        if (items[num] != null)
        {
            Item temp;
            int tempInt;

            temp = items[num];
            tempInt = itemAmounts[num];

            items[num] = hotbar[hotbarNum];
            hotbarAmounts[hotbarNum] = itemAmounts[num];

            hotbar[num] = temp;
            hotbarAmounts[num] = tempInt;

        }

        if (items[num] == null)
        {
            items[num] = hotbar[hotbarNum];
            itemAmounts[num] = hotbarAmounts[hotbarNum];

            hotbar[hotbarNum] = null;
            hotbarAmounts[hotbarNum] = 0;

        }
    }
}
