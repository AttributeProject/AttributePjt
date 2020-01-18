using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Characters
{
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
    // Start is called before the first frame update
   override protected void Awake()
    {
        curAttribute = Attribute.FIRE;
        IsJump = false;
        CanMove = true;
        Weight = 2f;
        Speed = 10f;
        JumpPower = 10f;
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        CanDestroyed = false;
        Move();
        Jump();
        if (CanClimb) Climb(climbObject);
     
    }

    //이동
    private void Move()
    {
        float h = transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        transform.position = new Vector2(h, transform.position.y);
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
        float dir = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            this.transform.position = new Vector3(col.transform.position.x, this.transform.position.y, 0);
        }
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + dir, 0);


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

    //------------------------------------------Trigger 처리-------------------------------------------------
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ladder")
        {
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
                col.gameObject.GetComponent<Objects>().res_Fire();
                
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
            CanClimb = false;
        }
    }

}
