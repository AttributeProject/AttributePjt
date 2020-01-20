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
        //바뀌는거
        Debug.Log("속성상자 UpArrow Response");
        if (!isOpened)
        {
            Debug.Log("속성상자 OPEN");
            //속성상자 열리는 이벤트
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = opendBox;
            isOpened = true;
            //IsElementGet[1] = true;
            this.gameObject.GetComponent<ElementBox_Water>().IsOpen = true;

        }
        else
        {
            Debug.Log("속성상자 이미 열려있음");
        }
    }
}
