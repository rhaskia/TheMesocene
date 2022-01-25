using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreatureHealth : MonoBehaviour
{
    Info info;

    //health
    public int health;
    public int maxHealth;

    //hunger
    public int hunger;
    public int maxHunger;

    //thirst
    public int thirst;
    public int maxThirst;

    //ailments
    public enum Ailment { brokenBone, thirsty, hungry, bleeding, drowning, sick, poisoned, envemonated, frostbitten, concussed, lacerated, tranquilized }
    public Ailment[] Ailments;

    void Start()
    {
        info = FindObjectOfType<Info>();
    }

    void Update()
    {
        //Check Health
        if (health == 0)
        {
            info.manager.Die();//player mananger die;
        }
    }

    public void TakeDamage(int damage)
    {
        int DMG = Mathf.Clamp(damage, 0, health);

        health -= DMG;
    }

    public void GiveAilment(Ailment ailment)
    {
        List<Ailment> ailments = Ailments.ToList();

        ailments.Add(ailment);

        Ailments = ailments.ToArray();
    }

}
