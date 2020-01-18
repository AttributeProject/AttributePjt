using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    private bool isRise; // 물에 뜨는 가
    private bool canCatchFired; // 불이 붙는 가
    private bool isBurning;//타고있는 중인가
    private float timeToBurn;//타는데 걸리는 시간
    private float curTimeToBurn;//현재 불이붙고있는 과정에서 경과한 시간
    private bool getFired;  // 지금 불이 붙고 있는 과정인가
    private bool canMove; // 움직일 수 있는가
    private bool canMoved; // 움직여질 수 있는가
    private bool canDestroyed; // 파괴될 수 있는가
    private float maxIndureImpurse;//견딜수 있는 최대 충격 량
    private bool isRolling; // 굴러갈 수 있는가
    private float weight; // 무게

    public bool CanCatchFired { get => canCatchFired; set => canCatchFired = value; }
    public bool CanMove { get => canMove; set => canMove = value; }
    public bool CanMoved { get => canMoved; set => canMoved = value; }
    public bool CanDestroyed { get => canDestroyed; set => canDestroyed = value; }
    public bool IsRolling { get => isRolling; set => isRolling = value; }
    public float Weight { get => weight; set => weight = value; }
    public bool IsRise { get => isRise; set => isRise = value; }
    public bool IsBurning { get => isBurning; set => isBurning = value; }
    public float MaxIndureImpurse { get => maxIndureImpurse; set => maxIndureImpurse = value; }
    public float TimeToBurn { get => timeToBurn; set => timeToBurn = value; }
    public bool GetFired { get => getFired; set => getFired = value; }
    public float CurTimeToBurn { get => curTimeToBurn; set => curTimeToBurn = value; }


    // Start is called before the first frame update
    virtual protected void Awake()
    {
        IsBurning = false;
        curTimeToBurn = 0f;
        CanMove = false;
        CanMoved = false;
        IsRise = false;
        IsRolling = false;
        MaxIndureImpurse = 0f;

    }


    // Update is called once per frame
    virtual protected void Update()
    {

    }
    virtual public void burnThisObject()
    {
        Debug.Log("i'm buring" + this.gameObject.name + " ");
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = null;//null자리에 새로운 스프라이트 들어가야됨
        //Destroy(this.gameObject, time);
    }
    virtual protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Ground")
            if (col.gameObject.GetComponent<Objects>().CanDestroyed)
            {
                //충격량이 일정 이상일 경우
                if (true/* maxIndureImpurse <받은 충격 */)
                {
                    //부서지는 시각적 효과 함수();
                    Debug.Log(col.relativeVelocity);
                    // Destroy(col.gameObject);
                }
            }
    }
    virtual public void res_UpArrow()
    {

    }
    virtual public void res_Fire()
    {

    }
    virtual public void res_Water()
    {

    }
}
