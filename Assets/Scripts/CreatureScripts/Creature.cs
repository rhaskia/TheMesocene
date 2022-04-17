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

[CreateAssetMenu(fileName = "Critter")]
public class Creature : ScriptableObject
{
    public float sneakSpeed = 0.5f;
    public float walkSpeed = 1;
    public float runSpeed = 2;

    public int size = 1;

    public AnimationBundle idle, walk, run, jump, glide, fly, rest, sleep, eat, drink, lmb, rmb, limp, death;

    public Sprite dead;
}
