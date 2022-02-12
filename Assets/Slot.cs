using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    Image item;
    public Sprite sprite;
    public bool draggable;
    public bool hotbar;
    public int num;
    public Sprite empty;

    public void Start()
    {
        item = transform.GetChild(0).gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        item.sprite = sprite;
        draggable = (transform.GetChild(0).GetComponent<Image>().sprite != null || transform.GetChild(0).GetComponent<Image>().sprite != empty);
    }
}
