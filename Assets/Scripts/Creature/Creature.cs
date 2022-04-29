using UnityEngine;

[System.Serializable]
public class AnimationBundle
{
    public Sprite[] side;
    public Sprite[] front;
    public Sprite[] back;
    public float speed;
}

[System.Serializable]
public class MoveType
{
    public float speed;
    public float staminaUse;
    public float minStamina = 10;
    public float disturbance; //for sneaking etc
    public bool can;
}

[CreateAssetMenu(fileName = "Critter")]
public class Creature : ScriptableObject
{
    public float size;

    public MoveType sneakSpeed, walkSpeed, trotSpeed, runSpeed, glideSpeed, flySpeed;

    public AnimationBundle idle, walk, run, jump, glide, fly, rest, sleep, eat, drink, lmb, rmb, limp, death;

    public Sprite dead;
}
