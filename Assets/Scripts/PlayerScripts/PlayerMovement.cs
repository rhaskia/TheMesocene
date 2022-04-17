using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Relations")]
    PlayerManager playerM;
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

    Creature creature;

    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
        playerM = FindObjectOfType<PlayerManager>();
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
        rb.velocity = speed * speedMult * ((playerM.growth.currentPercent / 2f) + 50f) / 100f;

        //Stamina
        stamina++;
        stamina = Mathf.Clamp(stamina, 0, maxStamina);

        creature = playerM.creature;
    }
    void Update()
    {
        //Groundcheck
        onGround = Physics.OverlapSphere(groundcheck.position, groundcheckRadius, groundLayer).Length != 0;

        //Jumping
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(rb.velocity.x, jumpForce, rb.velocity.z), ForceMode.Impulse);
        }
    }

    public float GetSpeed()
    {
        //If In Menu, Dont Move
        if (!onGround)
            return 0.5f;

        //Running
        Movement[] movements = new Movement[] { creature.sneakSpeed, creature.trotSpeed, creature.runSpeed };
        foreach (var move in movements)
        {
            if (Input.GetKey(move.key))
            {
                stamina -= move.staminaUse;
                if (stamina > move.minStamina)
                {
                    return move.speed;
                }
            }
        }

        stamina -= creature.walkSpeed.staminaUse;
        return creature.walkSpeed.speed;
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.GamePlay;
    }


}

