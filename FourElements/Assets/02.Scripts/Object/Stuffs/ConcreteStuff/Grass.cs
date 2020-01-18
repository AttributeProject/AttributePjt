using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : Unmoveable
{
    override protected void Awake()
    {
        base.Awake();
        CanCatchFired = true;
        TimeToBurn = 2f;
        CanDestroyed = false;
    }

    public override void res_Water()
    {
        Debug.Log("풀 Water Response");
    }
}
