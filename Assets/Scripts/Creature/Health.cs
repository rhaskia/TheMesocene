using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{

    [Header("Health")]
    public int health;
    public int maxHealth;

    [Header("Hunger")]
    public int hunger;
    public int maxHunger;

    [Header("Thirst")]
    public int thirst;
    public int maxThirst;

    //ailments
    public enum Ailment { brokenBone, thirsty, hungry, bleeding, drowning, sick, poisoned, envemonated, frostbitten, concussed, lacerated, tranquilized }
    public Ailment[] Ailments;

    public UnityEvent DeathFunction = new UnityEvent();


    void Update()
    {
        //Check Health
        if (health == 0)
        {
            DeathFunction.Invoke();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= Mathf.Clamp(damage, 0, health);
    }

    public void HealDamage(int heal)
    {
        health += Mathf.Clamp(heal, 0, maxHealth);
    }

    public void GiveAilment(Ailment ailment)
    {
        List<Ailment> ailments = Ailments.ToList();

        ailments.Add(ailment);

        Ailments = ailments.ToArray();
    }

}
