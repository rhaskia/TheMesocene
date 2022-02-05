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
    public float jumpForce;

    [Header("GroundCheck")]
    public float groundcheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform groundcheck;
    public bool onGround;

    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
        info = FindObjectOfType<Info>();
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
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
        //If In Menu, Dont Move
        if (!onGround)
            return 0.5f;

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

    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.GamePlay;
    }

    void Update()
    {
        onGround = Physics.OverlapSphere(groundcheck.position, groundcheckRadius, groundLayer).Length != 0;

        if (onGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(rb.velocity.x, jumpForce, rb.velocity.z), ForceMode.Impulse);
            }
        }
    }



}
