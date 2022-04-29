using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Keys")]
    public KeyCode trot;
    public KeyCode run, jump, crouch, glide, fly;

    public Movement move;

    private void Update()
    {
        //Input
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        move.moveInput = GetInput();
    }

    MoveInput GetInput()
    {
        return new MoveInput(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")),
            Input.GetKeyDown(crouch), Input.GetKey(trot), Input.GetKey(run),
            Input.GetKeyDown(jump), Input.GetKeyDown(glide), Input.GetKeyDown(fly),
            Input.GetKey(crouch), Input.GetKey(jump));
    }

}