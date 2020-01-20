using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : Unmovable
{
    // Start is called before the first frame update
    override protected void Awake()
    {
        CanCatchFired = true;
        TimeToBurn = 2f;
        CanDestroyed = false;
    }

    override public void res_UpArrow()
    {
        //사다리랑 같은 로직 넣으면됨
        Debug.Log("밧줄 UpArrow Response");
    }
    override public void res_Fire()
    {
        Debug.Log("밧줄 Fire Response");
        //로프 타야됨
    }

}
