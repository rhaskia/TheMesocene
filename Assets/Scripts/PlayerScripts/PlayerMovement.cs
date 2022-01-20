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
                return info.PMA.creature.RunSpeed;
            }
        }
        //Trotting
        else if (Input.GetKey(KeyCode.Z))
        {
            stamina -= 2;
            if (stamina > 10)
            {
                return ((info.PMA.creature.RunSpeed - info.PMA.creature.WalkSpeed) / 2) + info.PMA.creature.WalkSpeed;
            }
        }

        //Walking
        return info.PMA.creature.WalkSpeed;
    }

}
