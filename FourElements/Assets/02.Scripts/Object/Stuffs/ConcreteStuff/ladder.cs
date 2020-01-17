using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : Unmoveable
{
    override public void burnThisObject(float time)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = null;//null자리에 새로운 스프라이트 들어가야됨
        Destroy(this.gameObject, time);
    }
}
