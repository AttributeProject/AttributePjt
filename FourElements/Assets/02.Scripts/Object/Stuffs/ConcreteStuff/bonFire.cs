using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonFire : Unmovable
{
    override protected void Awake()
    {
        base.Awake();
        CanCatchFired = false;
        CanDestroyed = false;
    }
    override public void res_Water()
    {
        Debug.Log("모닥불 Water Response");
    }
}
