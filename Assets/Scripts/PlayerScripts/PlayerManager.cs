using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    Info info;

    public Creature creature;

    public Slider Health;
    public Slider Stamina;

    public Slider Thirst;
    public Slider Hunger;

    // Start is called before the first frame update
    void Start()
    {
        info = FindObjectOfType<Info>();
        info.PA.current = creature;
    }

    // Update is called once per frame
    void Update()
    {
        //UI
        Health.value = info.PH.health / (info.PH.maxHealth * 1f);
        Stamina.value = info.PMO.stamina / (info.PMO.maxStamina * 1f);
        Thirst.value = info.PH.thirst / (info.PH.maxThirst * 1f);
        Hunger.value = info.PH.hunger / (info.PH.maxHunger * 1f);
    }

    internal void Die()
    {
        throw new NotImplementedException();
    }
}
