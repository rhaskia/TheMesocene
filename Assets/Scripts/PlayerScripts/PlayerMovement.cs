using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Variables")]
    public Vector2 MoveSpeed;

    [Header("Relations")]
    public Rigidbody Rigidbody;
    public Info info;
    public SpriteRenderer Render;
    public Creature current;

    private void Start()
    {
        Invoke("Animation", 0.25f);
    }

    private void FixedUpdate()
    {
        //Input
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 speed = new Vector3(input.normalized.x * MoveSpeed.x, 0, input.normalized.y * MoveSpeed.y);

        //Applying Input
        Rigidbody.velocity = speed;

        //Flipping
        if (input.x > 0.01)
        {
            Render.flipX = true;
            info.PA.shadow.flipX = true;
        }
        else
        {
            Render.flipX = false;
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
