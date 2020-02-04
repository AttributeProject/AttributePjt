using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBox : Movable
{
    protected override void Awake()
    {
        base.Awake();
        CanCatchFired = true;
        TimeToBurn = 2f;
        CanDestroyed = true;
        MaxIndureImpurse = 3;//temp value
    }
    override public void res_Fire()
    {
        Debug.Log("나무상자 Fire Response");
    }
 
}
