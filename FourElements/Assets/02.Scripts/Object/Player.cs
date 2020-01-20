using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Characters
{
    private bool[] isElementGet = new bool[4];
    [SerializeField]
    private GameObject elementsTab;
    [SerializeField]
    private Sprite[] appearance = new Sprite[4];
    enum Attribute
    {
        FIRE,
        WATER,
        EARTH,
        AIR,
    }
    private Attribute curAttribute;
    private Rigidbody2D rigid;

    Collider2D climbObject; //오르기 명령을 내릴 경우 올라야 할 오브젝트의 collider

    public bool[] IsElementGet { get => isElementGet; set => isElementGet = value; }

    // Start is called before the first frame update
    override protected void Awake()
    {
        curAttribute = Attribute.FIRE;
        IsElementGet[0] = true;
        IsJump = false;
        CanMove = true;
        Weight = 2f;
        Speed = 10f;
        JumpPower = 10f;
        rigid = GetComponent<Rigidbody2D>();
        SetStats();
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        
        CanDestroyed = false;
        if (Input.GetKey(KeyCode.Tab))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            elementsTab.SetActive(true);
            ChangeProperty();
        }
        else
        {
            elementsTab.SetActive(false);
            if (CanClimb) Climb(climbObject);
            else
            {
                Jump();
            }
            Move();
        }
        if (CanClimb) Climb(climbObject);

    }
    //특성에 따른 스탯 변화
    private void SetStats()
    {
        if (Property == 0)
        {
            Weight = 1f;
            Speed = 15f;
            JumpPower = 25f;
        }
        else if (Property == 1)
        {
            Weight = 1f;
            Speed = 10f;
            JumpPower = 20f;
        }
        else if (Property == 2)
        {
            Weight = 4f;
            Speed = 10f;
            JumpPower = 20f;
        }
        else if (Property == 3)
        {
            Weight = 0.5f;
            Speed = 10f;
            JumpPower = 20f;
        }
        else
        {
            Weight = 2f;
            Speed = 10f;
            JumpPower = 20f;
        }
    }
    //이동
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        if (h < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else if (h > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        transform.position = new Vector2(transform.position.x + h * Time.deltaTime * (Speed / Weight), transform.position.y);
    }

    //점프
    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && !IsJump)
        {
            rigid.AddForce(Vector2.up * JumpPower / Weight, ForceMode2D.Impulse);
            IsJump = true;
        }
    }

    private void Climb(Collider2D col)
    {
        float dir = Input.GetAxis("Vertical") * Time.deltaTime * (Speed / Weight);
        if (dir != 0f)
        {
            Physics2D.IgnoreLayerCollision(10, 8, true);
            this.transform.position += new Vector3(0, dir, 0);
        }

    }
    // 속성 바꾸기
    private void ChangeProperty()
    {
        if (IsElementGet[0] == true)
        {
            elementsTab.transform.GetChild(0).gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                elementsTab.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                gameObject.GetComponent<SpriteRenderer>().sprite = appearance[0];
                Property = 0;
            }
        }
        if (IsElementGet[1] == true)
        {
            elementsTab.transform.GetChild(1).gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.RightArrow))
            {
                elementsTab.transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                gameObject.GetComponent<SpriteRenderer>().sprite = appearance[1];
                Property = 1;
            }
        }
        if (IsElementGet[2] == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = appearance[2];

        }
        if (IsElementGet[3] == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = appearance[3];

        }
        SetStats();
        elementsTab.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 127);
        elementsTab.transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 127);

    }
    //------------------------------------------Collision 처리-----------------------------------------------
    //collision과 접촉을 한 경우
    override protected void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
        if (col.gameObject.tag == "Ground")
        {
            IsJump = false;
        }
        //만약 내가 불 속성이고 충돌한 물체가 불이 붙을 수 있는 오브젝트라면
        if (col.gameObject.tag != "Ground")
            if (curAttribute == Attribute.FIRE && col.gameObject.GetComponent<Objects>().CanCatchFired)
            {
                Debug.Log("burn");
                // 태운다
                col.gameObject.GetComponent<Objects>().burnThisObject();
            }
    }
    // collision과 접촉 상태를 유지하고 있는경우
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "WoodBox")
        {
            Debug.Log("상자 미는중");
            float h = Input.GetAxis("Horizontal") * Time.deltaTime * Speed * 0.2f;
            col.gameObject.transform.position += new Vector3(h, 0, 0);
            transform.position += new Vector3(h, 0, 0);
        }

    }
    // collision과 접촉 상태를 유지하고 있는경우
    private void OnStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WoodBox")
        {
            float h = Input.GetAxis("Horizontal") * Time.deltaTime * Speed * 0.2f;
            collision.gameObject.transform.position += new Vector3(h, 0, 0);
            transform.position += new Vector3(h, 0, 0);
        }
    }
    //------------------------------------------Trigger 처리-------------------------------------------------
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            rigid.gravityScale = 0f;
            CanClimb = true;
            climbObject = col;
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log(col.name + " 트리거 접촉중");
        if (col.gameObject.tag != "Ground")
            if (curAttribute == Attribute.FIRE && col.gameObject.GetComponent<Objects>().CanCatchFired)
            {
                Debug.Log("burn");
                // col.gameObject.GetComponent<Objects>().res_Fire();

            }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log(col.name + " 트리거 접촉중 UpArrow 누름");
            col.GetComponent<Objects>().res_UpArrow();
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            Physics2D.IgnoreLayerCollision(10, 8, false);
            rigid.gravityScale = 2f;
            CanClimb = false;
        }
    }

}
