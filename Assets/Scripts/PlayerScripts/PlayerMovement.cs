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
    public Rigidbody rigidbody;
    public SpriteRenderer render;
    public Creature current;

    private void Start()
    {
        Invoke("Animation", 0.25f);
        info = FindObjectOfType<Info>();
    }

    private void FixedUpdate()
    {
        //Input
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 speed = new Vector3(input.normalized.x * moveSpeed.x, 0, input.normalized.y * moveSpeed.y);

        //Applying Input
        rigidbody.velocity = speed;

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
    }

}
