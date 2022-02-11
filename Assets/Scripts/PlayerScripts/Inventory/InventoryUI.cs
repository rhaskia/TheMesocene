using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Info info;
    public int pageNumber;
    public Image[] images;
    public Slot[] slots;
    public Slot[] hotbar;
    public Color active;
    public Color inactive;
    public Sprite empty;

    // Start is called before the first frame update
    void Start()
    {
        info = FindObjectOfType<Info>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameState currentGameState = GameStateManager.Instance.currentGameState;
            GameState newGameState = currentGameState == GameState.GamePlay
                ? GameState.Paused
                : GameState.GamePlay;

            GameStateManager.Instance.SetState(newGameState);

            transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeInHierarchy);
        }

        UpdateInventory();
    }

    public void OpenPage(int page)
    {
        images[pageNumber].color = inactive;

        pageNumber = page;

        images[pageNumber].color = active;
    }

    public void UpdateInventory()
    {
        for (int i = 0; i < info.inven.items.Count; i++)
        {
            if (info.inven.items[i] == null)
                slots[i].sprite = empty;
            else
                slots[i].sprite = info.inven.items[i].sprite;
        }

        for (int i = 0; i < info.inven.hotbar.Count; i++)
        {
            if (info.inven.hotbar[i] == null)
                hotbar[i].sprite = empty;
            else
                hotbar[i].sprite = info.inven.hotbar[i].sprite;
        }
    }
}
