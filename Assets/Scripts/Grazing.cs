using UnityEngine;

public class Grazing : MonoBehaviour
{

    public float speed;
    public float distance;

    private bool movingright = true;

    public Transform groundDetection;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingright == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingright = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingright = true;
            }

        }

    }
}

