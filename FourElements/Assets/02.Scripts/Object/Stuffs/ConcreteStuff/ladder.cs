using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : Unmoveable
{
    [SerializeField]
    private Sprite[] ladderSprite = new Sprite[4];


    override protected void Awake()
    {
        base.Awake();
        CanCatchFired = true;
        TimeToBurn = 2f;
        CanDestroyed = false;

    }
    protected override void Update()
    {
        base.Update();
        /*
        if(GetFired)
        {
            CurTimeToBurn += Time.deltaTime;
            Debug.Log("시간"+CurTimeToBurn);
            //현재 진행된 발화시간이 불이 붙을 수 있는 시간 이상 경과 했을 경우
            if (CurTimeToBurn > TimeToBurn)
            {
                CurTimeToBurn=0;
                GetFired = false;
                burnThisObject();   
            }
        }*/
    }
    override public void burnThisObject()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = ladderSprite[1];//탄 스프라이트 넣음
        //Destroy(this.gameObject, time);
    }
    override public void res_UpArrow()
    {
        Debug.Log("사다리 UpArrow Response");
    }
}
