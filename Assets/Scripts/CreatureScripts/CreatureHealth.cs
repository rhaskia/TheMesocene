using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreatureHealth : MonoBehaviour
{

    public int health;
    public int maxHealth;

    Info info;

    public enum Ailment { brokenBone, thirsty, hungry, bleeding, drowning, sick, poisoned, envemonated, frostbitten, concussed, lacerated, tranquilized }
    public Ailment[] Ailments;

    // Start is called before the first frame update
    void Start()
    {
        info = FindObjectOfType<Info>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            info.PMA.Die();//player mananger die;
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
