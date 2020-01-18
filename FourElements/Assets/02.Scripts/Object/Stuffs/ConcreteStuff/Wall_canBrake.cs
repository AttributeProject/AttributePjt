using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_canBrake : Unmoveable
{
    protected override void Awake()
    {
        base.Awake();
        CanCatchFired = false;
        CanDestroyed = true;
        MaxIndureImpurse = 3f;//temp value
    }
}
