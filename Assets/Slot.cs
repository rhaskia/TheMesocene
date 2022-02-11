using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    Image item;
    public Sprite sprite;

    public void Start()
    {
        item = transform.GetChild(0).gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        item.sprite = sprite;
    }
}
