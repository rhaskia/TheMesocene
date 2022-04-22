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

    [Header("Keys")]
    public KeyCode trot;
    public KeyCode run, jump, crouch, fly;

    Creature creature;

    public bool crouching, flying;

    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
        playerM = FindObjectOfType<PlayerManager>();
        creature = playerM.creature;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    private void FixedUpdate()
    {
        //Input
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 speed = new Vector3(input.normalized.x * moveSpeed.x, 0, input.normalized.y * moveSpeed.y);
        float speedMult = GetSpeed(input.normalized.x + input.normalized.y);

        //Applying Input If On Ground
        Vector3 i = speed * speedMult * ((playerM.growth.currentPercent / 2f) + 50f) / 100f;
        if (onGround || flying) rb.velocity = new Vector3(i.x, rb.velocity.y, i.z);

        //Stamina
        stamina++;
        stamina = Mathf.Clamp(stamina, 0, maxStamina);

        //idk
        creature = playerM.creature;
    }
    void Update()
    {
        //Groundcheck
        onGround = Physics.OverlapSphere(groundcheck.position, groundcheckRadius, groundLayer).Length != 0;

        //Jumping
        if (onGround && Input.GetKeyDown(jump))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }

        //Flying
        if (!onGround && Input.GetKeyDown(fly)) flying = !flying;
        if (onGround) flying = false;

        if (flying)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.99f);

            if (Input.GetKey(jump)) rb.AddForce(new Vector3(0, 0.1f, 0), ForceMode.Impulse);
            if (Input.GetKey(crouch)) rb.AddForce(new Vector3(0, -0.1f, 0), ForceMode.Impulse);
        }

        rb.useGravity = !flying;

        //Crouching
        if (onGround && Input.GetKeyDown(crouch)) crouching = !crouching;
    }

    public float GetSpeed(float input)
    {
        //If In Menu, Dont Move

        //Trotting
        if (Input.GetKey(trot))
        {
            stamina -= creature.runSpeed.staminaUse;
            if (stamina > creature.runSpeed.minStamina) return creature.runSpeed.speed;
            crouching = false;
        }

        //Running
        if (Input.GetKey(run))
        {
            stamina -= creature.runSpeed.staminaUse;
            if (stamina > creature.runSpeed.minStamina) return creature.runSpeed.speed;
            crouching = false;
        }

        //Crouching
        if (crouching) return creature.sneakSpeed.speed;

        if (input > 0.1f) stamina -= creature.walkSpeed.staminaUse;
        return creature.walkSpeed.speed;
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.GamePlay;
    }

}