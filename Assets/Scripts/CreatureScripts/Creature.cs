using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Critter")]
public class Creature : ScriptableObject
{
    public float sneakSpeed = 0.5f;
    public float walkSpeed = 1;
    public float runSpeed = 2;

    public int size = 1;

    public Sprite[] walkAnimSide;
    public Sprite[] walkAnimFront;
    public Sprite[] walkAnimBack;
    public float walkAnimSpeed = 0.15f;

    public Sprite[] runAnimSide;
    public Sprite[] runAnimFront;
    public Sprite[] runAnimBack;
    public float runAnimSpeed = 0.15f;

    public bool canJump;
    public Sprite[] jumpAnimSide;
    public Sprite[] jumpAnimFront;
    public Sprite[] jumpAnimBack;
    public float jumpAnimSpeed = 0.15f;

    public bool canGlide;
    public Sprite[] glideAnimSide;
    public Sprite[] glideAnimFront;
    public Sprite[] glideAnimBack;
    public float glideAnimSpeed = 0.15f;

    public bool canFly;
    public Sprite[] flyAnimSide;
    public Sprite[] flyAnimFront;
    public Sprite[] flyAnimBack;
    public float flyAnimSpeed = 0.15f;

    public Sprite[] restAnimSide;
    public Sprite[] restAnimFront;
    public Sprite[] restAnimBack;
    public float restAnimSpeed = 0.15f;

    public Sprite[] sleepAnimSide;
    public Sprite[] sleepAnimFront;
    public Sprite[] sleepAnimBack;
    public float sleepAnimSpeed = 0.15f;

    public Sprite[] eatAnimSide;
    public Sprite[] eatAnimFront;
    public Sprite[] eatAnimBack;
    public float eatAnimSpeed = 0.15f;

    public Sprite[] drinkAnimSide;
    public Sprite[] drinkAnimFront;
    public Sprite[] drinkAnimBack;
    public float drinkAnimSpeed = 0.15f;

    public Sprite[] LMBAnimSide;
    public Sprite[] LMBAnimFront;
    public Sprite[] LMBAnimBack;
    public float LMBAnimSpeed = 0.15f;

    public Sprite[] RMBAnimSide;
    public Sprite[] RMBAnimFront;
    public Sprite[] RMBAnimBack;
    public float RMBAnimSpeed = 0.15f;

    public Sprite[] limpAnimSide;
    public Sprite[] limpAnimFront;
    public Sprite[] limpAnimBack;
    public float limpAnimSpeed = 0.15f;

    public Sprite[] deathAnimSide;
    public Sprite[] deathAnimFront;
    public Sprite[] deathAnimBack;
    public float deathAnimSpeed = 0.15f;

    public Sprite[] idleAnimSide;
    public Sprite[] idleAnimFront;
    public Sprite[] idleAnimBack;
    public float idleAnimSpeed = 0.15f;

    public Sprite dead;

}
