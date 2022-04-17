using UnityEngine;

[System.Serializable]
public class AnimationBundle
{
    public Sprite[] side;
    public Sprite[] front;
    public Sprite[] back;
    public float speed;
    public bool can;
}

[System.Serializable]
public class Movement
{
    public float speed;
    public float staminaUse;
    public float minStamina = 10;
    public KeyCode key;
    public float disturbance; //for sneaking etc
}

[CreateAssetMenu(fileName = "Critter")]
public class Creature : ScriptableObject
{
    public Movement sneakSpeed, walkSpeed, trotSpeed, runSpeed;

    public int size = 1;

    public AnimationBundle idle, walk, run, jump, glide, fly, rest, sleep, eat, drink, lmb, rmb, limp, death;

    public Sprite dead;
}
