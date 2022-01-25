using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [Header("Relations")]
    Info info;
    public Rigidbody rb;
    public SpriteRenderer render;

    [Header("Variables")]
    public Slider health;
    public Slider stamina;
    public Slider thirst;
    public Slider hunger;

    void Start()
    {
        info = FindObjectOfType<Info>();
        info.animater.current = info.creature;
    }

    void Update()
    {
        //Input
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //UI
        health.value = info.health.health / (info.health.maxHealth * 1f);
        stamina.value = info.movement.stamina / (info.movement.maxStamina * 1f);
        thirst.value = info.health.thirst / (info.health.maxThirst * 1f);
        hunger.value = info.health.hunger / (info.health.maxHunger * 1f);

        //Flipping
        if (input.x > 0.01)
        {
            render.flipX = true;
            info.animater.shadow.flipX = true;
        }
        else if (input.x < -0.01)
        {
            render.flipX = false;
            info.animater.shadow.flipX = false;
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
            info.animater.currentAnim == CreatureAnimation.Animations.idle ||
            info.animater.currentAnim == CreatureAnimation.Animations.run ||
            info.animater.currentAnim == CreatureAnimation.Animations.walk;

        if (movingAnims)
        {
            if (rb.velocity.x + rb.velocity.z > info.creature.walkSpeed + 0.01f || rb.velocity.x + rb.velocity.z < -info.creature.walkSpeed + 0.01f)
            {
                info.animater.currentAnim = CreatureAnimation.Animations.run;
            }
            else if (rb.velocity.x + rb.velocity.z > info.creature.walkSpeed / 8f || rb.velocity.x + rb.velocity.z < -info.creature.walkSpeed / 8f)
            {
                info.animater.currentAnim = CreatureAnimation.Animations.walk;
            }
            else
            {
                info.animater.currentAnim = CreatureAnimation.Animations.idle;
            }
        }

    }
}
