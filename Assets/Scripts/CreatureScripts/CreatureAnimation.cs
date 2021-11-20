using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAnimation : MonoBehaviour
{
    Info info;
    public enum Animations { Idle, Walk, Run, Jump, Glide, Fly, Rest, Sleep, Eat, Drink, LMB, RMB, Limp, Death }
    public enum Directions { Side, Front, Back }

    [Header("Info")]
    public Animations currentAnim;
    public Directions currentDir;
    public int currentFrame;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer shadow;

    void Start()
    {
        info = (Info)FindObjectOfType(typeof(Info));
        Invoke("Animation", 0.1f);
    }

    void Animation()
    {
        switch (currentAnim)
        {
            case Animations.Idle:
                AnimationSet(info.PM.current.IdleAnimSide, info.PM.current.IdleAnimFront, info.PM.current.IdleAnimBack);
                Invoke("Animation", info.PM.current.IdleAnimSpeed);
                break;
            case Animations.Walk:
                AnimationSet(info.PM.current.WalkAnimSide, info.PM.current.WalkAnimFront, info.PM.current.WalkAnimBack);
                Invoke("Animation", info.PM.current.WalkAnimSpeed);
                break;
            case Animations.Run:
                AnimationSet(info.PM.current.RunAnimSide, info.PM.current.RunAnimFront, info.PM.current.RunAnimBack);
                Invoke("Animation", info.PM.current.RunAnimSpeed);
                break;
            case Animations.Jump:
                AnimationSet(info.PM.current.JumpAnimSide, info.PM.current.JumpAnimFront, info.PM.current.JumpAnimBack);
                Invoke("Animation", info.PM.current.JumpAnimSpeed);
                break;
            case Animations.Glide:
                AnimationSet(info.PM.current.GlideAnimSide, info.PM.current.GlideAnimFront, info.PM.current.GlideAnimBack);
                Invoke("Animation", info.PM.current.GlideAnimSpeed);
                break;
            case Animations.Fly:
                AnimationSet(info.PM.current.FlyAnimSide, info.PM.current.FlyAnimFront, info.PM.current.FlyAnimBack);
                Invoke("Animation", info.PM.current.FlyAnimSpeed);
                break;
            case Animations.Rest:
                AnimationSet(info.PM.current.RestAnimSide, info.PM.current.RestAnimFront, info.PM.current.RestAnimBack);
                Invoke("Animation", info.PM.current.RestAnimSpeed);
                break;
            case Animations.Sleep://i need sleep
                AnimationSet(info.PM.current.SleepAnimSide, info.PM.current.SleepAnimFront, info.PM.current.SleepAnimBack);
                Invoke("Animation", info.PM.current.SleepAnimSpeed);
                break;
            case Animations.Eat:
                AnimationOneTime(info.PM.current.EatAnimSide, info.PM.current.EatAnimFront, info.PM.current.EatAnimBack);
                Invoke("Animation", info.PM.current.EatAnimSpeed);
                break;
            case Animations.Drink:
                AnimationOneTime(info.PM.current.DrinkAnimSide, info.PM.current.DrinkAnimFront, info.PM.current.DrinkAnimBack);
                Invoke("Animation", info.PM.current.DrinkAnimSpeed);
                break;
            case Animations.LMB:
                AnimationSet(info.PM.current.LMBAnimSide, info.PM.current.LMBAnimFront, info.PM.current.LMBAnimBack);
                Invoke("Animation", info.PM.current.LMBAnimSpeed);
                break;
            case Animations.RMB:
                AnimationSet(info.PM.current.RMBAnimSide, info.PM.current.RMBAnimFront, info.PM.current.RMBAnimBack);
                Invoke("Animation", info.PM.current.RMBAnimSpeed);
                break;
            case Animations.Limp:
                AnimationSet(info.PM.current.LimpAnimSide, info.PM.current.LimpAnimFront, info.PM.current.LimpAnimBack);
                Invoke("Animation", info.PM.current.LimpAnimSpeed);
                break;
            case Animations.Death:
                AnimationSet(info.PM.current.DeathAnimSide, info.PM.current.DeathAnimFront, info.PM.current.DeathAnimBack);
                Invoke("Animation", info.PM.current.DeathAnimSpeed);
                break;

        }

    }

    void AnimationSet(Sprite[] side, Sprite[] front, Sprite[] back)
    {
        switch (currentDir)
        {
            case Directions.Side:
                if (currentFrame >= side.Length)
                { currentFrame = 0; }
                spriteRenderer.sprite = side[currentFrame];
                shadow.sprite = side[currentFrame];
                break;
            case Directions.Front:
                if (currentFrame >= front.Length)
                { currentFrame = 0; }
                spriteRenderer.sprite = front[currentFrame];
                shadow.sprite = front[currentFrame];
                break;
            case Directions.Back:
                if (currentFrame >= back.Length)
                { currentFrame = 0; }
                spriteRenderer.sprite = back[currentFrame];
                shadow.sprite = back[currentFrame];
                break;
        }
        currentFrame++;

    }

    void AnimationOneTime(Sprite[] side, Sprite[] front, Sprite[] back)
    {
        switch (currentDir)
        {
            case Directions.Side:
                if (currentFrame >= side.Length)
                { currentAnim = Animations.Idle; currentFrame = 0; }
                spriteRenderer.sprite = side[currentFrame];
                break;
            case Directions.Front:
                if (currentFrame >= front.Length)
                { currentAnim = Animations.Idle; currentFrame = 0; }
                spriteRenderer.sprite = front[currentFrame];
                break;
            case Directions.Back:
                if (currentFrame >= back.Length)
                { currentAnim = Animations.Idle; currentFrame = 0; }
                spriteRenderer.sprite = back[currentFrame];
                break;
        }
        currentFrame++;

    }
}
