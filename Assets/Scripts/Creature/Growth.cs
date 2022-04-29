using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Growth : MonoBehaviour
{
    public enum GS { hatchling, baby, juvenile, subadult, adult, elder }
    public GS stage;
    public int currentPercent = 10;

    [Header("Percentages")]
    public int hatchling = 10;
    public int baby = 30;
    public int juvenile = 50;
    public int subadult = 80;
    public int adult = 100;
    public int elder = 90;

    public UnityEvent GrowFunction = new UnityEvent();
    public UnityEvent DieFunction = new UnityEvent();

    public void Start()
    {
        switch (stage)
        {
            case GS.hatchling: currentPercent = hatchling; break;
            case GS.baby: currentPercent = baby; break;
            case GS.juvenile: currentPercent = juvenile; break;
            case GS.subadult: currentPercent = subadult; break;
            case GS.adult: currentPercent = adult; break;
            case GS.elder: currentPercent = elder; break;
        }
    }

    public void Grow()
    {
        GrowFunction.Invoke();

        switch (stage)
        {
            case GS.hatchling: currentPercent = baby; stage = GS.baby; break;
            case GS.baby: currentPercent = juvenile; stage = GS.juvenile; break;
            case GS.juvenile: currentPercent = subadult; stage = GS.subadult; break;
            case GS.subadult: currentPercent = adult; stage = GS.adult; break;
            case GS.adult: currentPercent = elder; stage = GS.elder; break;
            case GS.elder: DieFunction.Invoke(); break;
        }

    }

}
