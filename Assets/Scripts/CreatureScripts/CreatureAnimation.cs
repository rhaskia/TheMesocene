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
    public Creature current;

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
                AnimationSet(current.IdleAnimSide, current.IdleAnimFront, current.IdleAnimBack);
                Invoke("Animation", current.IdleAnimSpeed);
                break;
            case Animations.Walk:
                AnimationSet(current.WalkAnimSide, current.WalkAnimFront, current.WalkAnimBack);
                Invoke("Animation", current.WalkAnimSpeed);
                break;
            case Animations.Run:
                AnimationSet(current.RunAnimSide, current.RunAnimFront, current.RunAnimBack);
                Invoke("Animation", current.RunAnimSpeed);
                break;
            case Animations.Jump:
                AnimationSet(current.JumpAnimSide, current.JumpAnimFront, current.JumpAnimBack);
                Invoke("Animation", current.JumpAnimSpeed);
                break;
            case Animations.Glide:
                AnimationSet(current.GlideAnimSide, current.GlideAnimFront, current.GlideAnimBack);
                Invoke("Animation", current.GlideAnimSpeed);
                break;
            case Animations.Fly:
                AnimationSet(current.FlyAnimSide, current.FlyAnimFront, current.FlyAnimBack);
                Invoke("Animation", current.FlyAnimSpeed);
                break;
            case Animations.Rest:
                AnimationSet(current.RestAnimSide, current.RestAnimFront, current.RestAnimBack);
                Invoke("Animation", current.RestAnimSpeed);
                break;
            case Animations.Sleep://i need sleep
                AnimationSet(current.SleepAnimSide, current.SleepAnimFront, current.SleepAnimBack);
                Invoke("Animation", current.SleepAnimSpeed);
                break;
            case Animations.Eat:
                AnimationOneTime(current.EatAnimSide, current.EatAnimFront, current.EatAnimBack);
                Invoke("Animation", current.EatAnimSpeed);
                break;
            case Animations.Drink:
                AnimationOneTime(current.DrinkAnimSide, current.DrinkAnimFront, current.DrinkAnimBack);
                Invoke("Animation", current.DrinkAnimSpeed);
                break;
            case Animations.LMB:
                AnimationSet(current.LMBAnimSide, current.LMBAnimFront, current.LMBAnimBack);
                Invoke("Animation", current.LMBAnimSpeed);
                break;
            case Animations.RMB:
                AnimationSet(current.RMBAnimSide, current.RMBAnimFront, current.RMBAnimBack);
                Invoke("Animation", current.RMBAnimSpeed);
                break;
            case Animations.Limp:
                AnimationSet(current.LimpAnimSide, current.LimpAnimFront, current.LimpAnimBack);
                Invoke("Animation", current.LimpAnimSpeed);
                break;
            case Animations.Death:
                AnimationSet(current.DeathAnimSide, current.DeathAnimFront, current.DeathAnimBack);
                Invoke("Animation", current.DeathAnimSpeed);
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
