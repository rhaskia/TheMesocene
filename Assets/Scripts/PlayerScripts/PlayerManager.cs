using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{
    [Header("Relations")]
    public Creature creature;
    public PlayerMovement movement;
    public CreatureAnimation animator;
    public CreatureHealth health;
    public CreatureGrowth growth;
    public CameraFollow follow;

    public Rigidbody rb;
    public SpriteRenderer render;

    [Header("Variables")]
    public Slider healthSlider;
    public Slider staminaSlider;
    public Slider thirstSlider;
    public Slider hungerSlider;

    void Start()
    {
        animator.current = creature;
        ManageGrowth();
    }

    void Update()
    {
        //Input
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //UI
        healthSlider.value = health.health / (health.maxHealth * 1f);
        staminaSlider.value = movement.stamina / (movement.maxStamina * 1f);
        thirstSlider.value = health.thirst / (health.maxThirst * 1f);
        hungerSlider.value = health.hunger / (health.maxHunger * 1f);

        //Flipping
        if (input.x > 0.01)
        {
            render.flipX = true;
            animator.shadow.flipX = true;
        }
        else if (input.x < -0.01)
        {
            render.flipX = false;
            animator.shadow.flipX = false;
        }

        //Animations
        ManageAnimations(input);
    }

    public void Die()
    {
        Debug.LogError("YOU DIED");
    }

    void ManageAnimations(Vector2 _input)
    {
        bool movingAnims =
            animator.currentAnim == CreatureAnimation.Animations.idle ||
            animator.currentAnim == CreatureAnimation.Animations.run ||
            animator.currentAnim == CreatureAnimation.Animations.walk;

        if (!movingAnims)
            return;

        if (rb.velocity.x + rb.velocity.z > creature.walkSpeed + 0.01f || rb.velocity.x + rb.velocity.z < -creature.walkSpeed + 0.01f)
        {
            animator.currentAnim = CreatureAnimation.Animations.run;
        }
        else if (rb.velocity.x + rb.velocity.z > creature.walkSpeed / 8f || rb.velocity.x + rb.velocity.z < -creature.walkSpeed / 8f)
        {
            animator.currentAnim = CreatureAnimation.Animations.walk;
        }
        else
        {
            animator.currentAnim = CreatureAnimation.Animations.idle;
        }
    }

    public void ManageGrowth()
    {
        float size = ((growth.currentPercent / 2f) + 50f) / 100f;

        transform.localScale = size * Vector3.one;
        follow.ZoomOffset = new Vector3(0f, size, -size);
    }
}