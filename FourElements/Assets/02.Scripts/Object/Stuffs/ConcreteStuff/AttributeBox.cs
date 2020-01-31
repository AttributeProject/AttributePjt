using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeBox : Unmovable
{
    Sprite opendBox;
    private bool isOpened=false;

    protected override void Awake()
    {
        base.Awake();
        CanCatchFired = false;
        CanDestroyed = false;
    }
    override public void res_UpArrow()
    {
        
    }
}
