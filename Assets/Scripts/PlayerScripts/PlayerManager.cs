using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [Header("Relations")]
    Info info;
    public Creature creature;
    public Rigidbody rb;
    public SpriteRenderer render;

    [Header("Variables")]
    public Slider Health;
    public Slider Stamina;
    public Slider Thirst;
    public Slider Hunger;

    void Start()
    {
        info = FindObjectOfType<Info>();
        info.PA.current = creature;
    }

    void Update()
    {
        //Input
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //UI
        Health.value = info.PH.health / (info.PH.maxHealth * 1f);
        Stamina.value = info.PMO.stamina / (info.PMO.maxStamina * 1f);
        Thirst.value = info.PH.thirst / (info.PH.maxThirst * 1f);
        Hunger.value = info.PH.hunger / (info.PH.maxHunger * 1f);

        //Flipping
        if (input.x > 0.01)
        {
            render.flipX = true;
            info.PA.shadow.flipX = true;
        }
        else if (input.x < -0.01)
        {
            render.flipX = false;
            info.PA.shadow.flipX = false;
        }

        //Animations
        ManageAnimations(input);
    }

    internal void Die()
    {
        throw new NotImplementedException();
    }

    void ManageAnimations(Vector2 _input)
    {
        bool movingAnims =
            info.PA.currentAnim == CreatureAnimation.Animations.Idle ||
            info.PA.currentAnim == CreatureAnimation.Animations.Run ||
            info.PA.currentAnim == CreatureAnimation.Animations.Walk;

        if (movingAnims)
        {
            if (rb.velocity.x + rb.velocity.z > creature.WalkSpeed + 0.01f || rb.velocity.x + rb.velocity.z < -creature.WalkSpeed + 0.01f)
            {
                info.PA.currentAnim = CreatureAnimation.Animations.Run;
            }
            else if (rb.velocity.x + rb.velocity.z > creature.WalkSpeed / 8f || rb.velocity.x + rb.velocity.z < -creature.WalkSpeed / 8f)
            {
                info.PA.currentAnim = CreatureAnimation.Animations.Walk;
            }
            else
            {
                info.PA.currentAnim = CreatureAnimation.Animations.Idle;
            }
        }

    }
}
