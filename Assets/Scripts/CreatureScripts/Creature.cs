using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Critter")]
public class Creature : ScriptableObject
{
    public Sprite Icon;

    public Sprite[] WalkAnimSide;
    public Sprite[] WalkAnimFront;
    public Sprite[] WalkAnimBack;
    public float WalkAnimSpeed;

    public Sprite[] RunAnimSide;
    public Sprite[] RunAnimFront;
    public Sprite[] RunAnimBack;
    public float RunAnimSpeed;

    public bool canJump;
    public Sprite[] JumpAnimSide;
    public Sprite[] JumpAnimFront;
    public Sprite[] JumpAnimBack;
    public float JumpAnimSpeed;

    public bool canGlide;
    public Sprite[] GlideAnimSide;
    public Sprite[] GlideAnimFront;
    public Sprite[] GlideAnimBack;
    public float GlideAnimSpeed;

    public bool canFly;
    public Sprite[] FlyAnimSide;
    public Sprite[] FlyAnimFront;
    public Sprite[] FlyAnimBack;
    public float FlyAnimSpeed;

    public Sprite[] RestAnimSide;
    public Sprite[] RestAnimFront;
    public Sprite[] RestAnimBack;
    public float RestAnimSpeed;

    public Sprite[] SleepAnimSide;
    public Sprite[] SleepAnimFront;
    public Sprite[] SleepAnimBack;
    public float SleepAnimSpeed;

    public Sprite[] EatAnimSide;
    public Sprite[] EatAnimFront;
    public Sprite[] EatAnimBack;
    public float EatAnimSpeed;

    public Sprite[] DrinkAnimSide;
    public Sprite[] DrinkAnimFront;
    public Sprite[] DrinkAnimBack;
    public float DrinkAnimSpeed;

    public Sprite[] LMBAnimSide;
    public Sprite[] LMBAnimFront;
    public Sprite[] LMBAnimBack;
    public float LMBAnimSpeed;

    public Sprite[] RMBAnimSide;
    public Sprite[] RMBAnimFront;
    public Sprite[] RMBAnimBack;
    public float RMBAnimSpeed;

    public Sprite[] LimpAnimSide;
    public Sprite[] LimpAnimFront;
    public Sprite[] LimpAnimBack;
    public float LimpAnimSpeed;

    public Sprite[] DeathAnimSide;
    public Sprite[] DeathAnimFront;
    public Sprite[] DeathAnimBack;
    public float DeathAnimSpeed;

    public Sprite[] IdleAnimSide;
    public Sprite[] IdleAnimFront;
    public Sprite[] IdleAnimBack;
    public float IdleAnimSpeed;
}
