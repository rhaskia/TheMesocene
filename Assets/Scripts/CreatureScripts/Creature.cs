using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Critter")]
public class Creature : ScriptableObject
{
    public Sprite Icon;

    public float WalkSpeed;
    public float RunSpeed;

    public Sprite[] WalkAnimSide;
    public Sprite[] WalkAnimFront;
    public Sprite[] WalkAnimBack;
    public float WalkAnimSpeed = 0.15f;

    public Sprite[] RunAnimSide;
    public Sprite[] RunAnimFront;
    public Sprite[] RunAnimBack;
    public float RunAnimSpeed = 0.15f;

    public bool canJump;
    public Sprite[] JumpAnimSide;
    public Sprite[] JumpAnimFront;
    public Sprite[] JumpAnimBack;
    public float JumpAnimSpeed = 0.15f;

    public bool canGlide;
    public Sprite[] GlideAnimSide;
    public Sprite[] GlideAnimFront;
    public Sprite[] GlideAnimBack;
    public float GlideAnimSpeed = 0.15f;

    public bool canFly;
    public Sprite[] FlyAnimSide;
    public Sprite[] FlyAnimFront;
    public Sprite[] FlyAnimBack;
    public float FlyAnimSpeed = 0.15f;

    public Sprite[] RestAnimSide;
    public Sprite[] RestAnimFront;
    public Sprite[] RestAnimBack;
    public float RestAnimSpeed = 0.15f;

    public Sprite[] SleepAnimSide;
    public Sprite[] SleepAnimFront;
    public Sprite[] SleepAnimBack;
    public float SleepAnimSpeed = 0.15f;

    public Sprite[] EatAnimSide;
    public Sprite[] EatAnimFront;
    public Sprite[] EatAnimBack;
    public float EatAnimSpeed = 0.15f;

    public Sprite[] DrinkAnimSide;
    public Sprite[] DrinkAnimFront;
    public Sprite[] DrinkAnimBack;
    public float DrinkAnimSpeed = 0.15f;

    public Sprite[] LMBAnimSide;
    public Sprite[] LMBAnimFront;
    public Sprite[] LMBAnimBack;
    public float LMBAnimSpeed = 0.15f;

    public Sprite[] RMBAnimSide;
    public Sprite[] RMBAnimFront;
    public Sprite[] RMBAnimBack;
    public float RMBAnimSpeed = 0.15f;

    public Sprite[] LimpAnimSide;
    public Sprite[] LimpAnimFront;
    public Sprite[] LimpAnimBack;
    public float LimpAnimSpeed = 0.15f;

    public Sprite[] DeathAnimSide;
    public Sprite[] DeathAnimFront;
    public Sprite[] DeathAnimBack;
    public float DeathAnimSpeed = 0.15f;

    public Sprite[] IdleAnimSide;
    public Sprite[] IdleAnimFront;
    public Sprite[] IdleAnimBack;
    public float IdleAnimSpeed = 0.15f;

    public Sprite Dead;
}
