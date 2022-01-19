using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Variables")]
    public Vector2 moveSpeed;
    public float stamina;
    public float maxStamina;

    [Header("Relations")]
    Info info;
    public Rigidbody rb;
    public SpriteRenderer render;

    private void Start()
    {
        Invoke("Animation", 0.25f);
        info = FindObjectOfType<Info>();
    }

    private void FixedUpdate()
    {
        //Input
        float speedMult = GetSpeed();

        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 speed = new Vector3(input.normalized.x * moveSpeed.x, 0, input.normalized.y * moveSpeed.y);

        //Applying Input
        rb.velocity = speed * speedMult;

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

        //Animation
        if (input.x > 0.001 || input.x < -0.001 || input.y > 0.001 || input.y < -0.001)
        {
            info.PA.currentAnim = CreatureAnimation.Animations.Walk;
        }
        else if (input == Vector2.zero && info.PA.currentAnim == CreatureAnimation.Animations.Walk)
        {
            info.PA.currentAnim = CreatureAnimation.Animations.Idle;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            info.PA.currentFrame = 0;
            info.PA.currentAnim = CreatureAnimation.Animations.Eat;

        }

        stamina++;
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
    }

    public float GetSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            stamina -= 3;
            if (stamina > 10)
                return info.PMA.creature.RunSpeed;
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            stamina -= 2;
            if (stamina > 10)
                return ((info.PMA.creature.RunSpeed - info.PMA.creature.WalkSpeed) / 2) + info.PMA.creature.WalkSpeed;
        }

        return info.PMA.creature.WalkSpeed;
    }

}
