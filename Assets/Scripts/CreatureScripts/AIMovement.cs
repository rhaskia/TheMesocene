using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public enum State
    {
        sleeping, wander, agressive, resting, fighting, fleeing, curious,
        hungry, thirsty, grazing, foraging, hunting, feeding,
        socializing, playing, afffectionate, nesting
    }
    public State state;

    void Update()
    {
        var stateStr = state.ToString();
        Invoke(char.ToUpper(stateStr[0]) + stateStr.Substring(1), 0f);
    }

    void Wander()
    {
        //
    }
}
