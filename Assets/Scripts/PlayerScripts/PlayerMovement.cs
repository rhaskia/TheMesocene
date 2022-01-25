using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Relations")]
    Info info;
    public Rigidbody rb;

    [Header("Variables")]
    public Vector2 moveSpeed;
    public float stamina;
    public float maxStamina;

    private void Start()
    {
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

        //Stamina
        stamina++;
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
    }

    public float GetSpeed()
    {
        //Running
        if (Input.GetKey(KeyCode.LeftShift))
        {
            stamina -= 3;
            if (stamina > 10)
            {
                return info.creature.runSpeed;
            }
        }
        //Trotting
        else if (Input.GetKey(KeyCode.Z))
        {
            stamina -= 2;
            if (stamina > 10)
            {
                return ((info.creature.runSpeed - info.creature.walkSpeed) / 2) + info.creature.walkSpeed;
            }
        }

        //Sneaking
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            return info.creature.sneakSpeed;
        }

        //Walking
        return info.creature.walkSpeed;
    }

}
