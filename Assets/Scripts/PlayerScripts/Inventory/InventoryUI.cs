using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public float pageNumber;

    // Start is called before the first frame update
    void Start()
    {

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
    }
}
