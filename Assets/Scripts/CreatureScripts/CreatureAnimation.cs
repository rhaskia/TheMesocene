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
        var allAnims = new AnimationBundle[] { current.idle, current.walk, current.run, current.jump, current.glide, current.fly, current.rest, current.sleep, current.eat, current.drink, current.lmb, current.rmb, current.limp, current.death };
        AnimationSet(allAnims[((int)currentAnim)]);
    }

    void AnimationSet(AnimationBundle anim)
    {
        switch (currentDir)
        {
            case Directions.Side:
                if (currentFrame >= anim.side.Length)
                { currentFrame = 0; }
                spriteRenderer.sprite = anim.side[currentFrame];
                shadow.sprite = anim.side[currentFrame];
                break;
            case Directions.Front:
                if (currentFrame >= anim.front.Length)
                { currentFrame = 0; }
                spriteRenderer.sprite = anim.front[currentFrame];
                shadow.sprite = anim.front[currentFrame];
                break;
            case Directions.Back:
                if (currentFrame >= anim.back.Length)
                { currentFrame = 0; }
                spriteRenderer.sprite = anim.back[currentFrame];
                shadow.sprite = anim.back[currentFrame];
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
