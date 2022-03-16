using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAnimation : MonoBehaviour
{
    public enum Animations { idle, walk, run, jump, glide, fly, rest, sleep, eat, drink, LMB, RMB, limp, death }
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
        Invoke("Animation", 0.1f);
    }

    void Animation()
    {
        switch (currentAnim)
        {
            case Animations.idle:
                AnimationSet(current.idleAnimSide, current.idleAnimFront, current.idleAnimBack);
                Invoke("Animation", current.idleAnimSpeed);
                break;
            case Animations.walk:
                AnimationSet(current.walkAnimSide, current.walkAnimFront, current.walkAnimBack);
                Invoke("Animation", current.walkAnimSpeed);
                break;
            case Animations.run:
                AnimationSet(current.runAnimSide, current.runAnimFront, current.runAnimBack);
                Invoke("Animation", current.runAnimSpeed);
                break;
            case Animations.jump:
                AnimationSet(current.jumpAnimSide, current.jumpAnimFront, current.jumpAnimBack);
                Invoke("Animation", current.jumpAnimSpeed);
                break;
            case Animations.glide:
                AnimationSet(current.glideAnimSide, current.glideAnimFront, current.glideAnimBack);
                Invoke("Animation", current.glideAnimSpeed);
                break;
            case Animations.fly:
                AnimationSet(current.flyAnimSide, current.flyAnimFront, current.flyAnimBack);
                Invoke("Animation", current.flyAnimSpeed);
                break;
            case Animations.rest:
                AnimationSet(current.restAnimSide, current.restAnimFront, current.restAnimBack);
                Invoke("Animation", current.restAnimSpeed);
                break;
            case Animations.sleep://i need sleep
                AnimationSet(current.sleepAnimSide, current.sleepAnimFront, current.sleepAnimBack);
                Invoke("Animation", current.sleepAnimSpeed);
                break;
            case Animations.eat:
                AnimationOneTime(current.eatAnimSide, current.eatAnimFront, current.eatAnimBack);
                Invoke("Animation", current.eatAnimSpeed);
                break;
            case Animations.drink:
                AnimationOneTime(current.drinkAnimSide, current.drinkAnimFront, current.drinkAnimBack);
                Invoke("Animation", current.drinkAnimSpeed);
                break;
            case Animations.LMB:
                AnimationSet(current.LMBAnimSide, current.LMBAnimFront, current.LMBAnimBack);
                Invoke("Animation", current.LMBAnimSpeed);
                break;
            case Animations.RMB:
                AnimationSet(current.RMBAnimSide, current.RMBAnimFront, current.RMBAnimBack);
                Invoke("Animation", current.RMBAnimSpeed);
                break;
            case Animations.limp:
                AnimationSet(current.limpAnimSide, current.limpAnimFront, current.limpAnimBack);
                Invoke("Animation", current.limpAnimSpeed);
                break;
            case Animations.death:
                AnimationSet(current.deathAnimSide, current.deathAnimFront, current.deathAnimBack);
                Invoke("Animation", current.deathAnimSpeed);
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
                { currentAnim = Animations.idle; currentFrame = 0; }
                spriteRenderer.sprite = side[currentFrame];
                break;
            case Directions.Front:
                if (currentFrame >= front.Length)
                { currentAnim = Animations.idle; currentFrame = 0; }
                spriteRenderer.sprite = front[currentFrame];
                break;
            case Directions.Back:
                if (currentFrame >= back.Length)
                { currentAnim = Animations.idle; currentFrame = 0; }
                spriteRenderer.sprite = back[currentFrame];
                break;
        }
        currentFrame++;

    }
}
