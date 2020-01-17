using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    private bool isRise; // 물에 뜨는 가
    [SerializeField]
    private bool canCatchFired; // 불이 붙는 가
    private bool isBuring;//타고있는 중인가
    private float timeToBurn;//타는데 걸리는 시간
    private bool isMove; // 움직일 수 있는가
    private bool isMoved; // 움직여질 수 있는가
    private bool canDestroyed; // 파괴될 수 있는가
    private float maxIndureImpurse;//견딜수 있는 최대 충격 량
    private bool isRolling; // 굴러갈 수 있는가
    private float height; // 높이
    private float width; // 너비
    private float weight; // 무게

    public bool CanCatchFired { get => canCatchFired; set => canCatchFired = value; }
    public bool IsMove { get => isMove; set => isMove = value; }
    public bool IsMoved { get => isMoved; set => isMoved = value; }
    public bool IsDestroyed { get => canDestroyed; set => canDestroyed = value; }
    public bool IsRolling { get => isRolling; set => isRolling = value; }
    public float Height { get => height; set => height = value; }
    public float Width { get => width; set => width = value; }
    public float Weight { get => weight; set => weight = value; }
    public bool IsRise { get => isRise; set => isRise = value; }
    public bool IsBuring { get => isBuring; set => isBuring = value; }
    public float MaxIndureImpurse { get => maxIndureImpurse; set => maxIndureImpurse = value; }
    public float TimeToBurn { get => timeToBurn; set => timeToBurn = value; }


    // Start is called before the first frame update
    void Awake()
    {
        TimeToBurn = 1;
        IsDestroyed = true;
        MaxIndureImpurse = 1;
       
    }

   
    // Update is called once per frame
    virtual protected  void Update()
    {
        
    }
    virtual public void burnThisObject(float time)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = null;//null자리에 새로운 스프라이트 들어가야됨
        Destroy(this.gameObject, time);
    }
    virtual protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Objects>().IsDestroyed)
        {
            //충격량이 일정 이상일 경우
            if (true/* maxIndureImpurse <받은 충격 */)
            {
                //부서지는 시각적 효과 함수();
                Debug.Log(col.relativeVelocity);
                Destroy(col.gameObject);
            }
        }

    }
}
