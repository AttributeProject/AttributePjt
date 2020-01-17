using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Characters
{
    private bool[] isElementGet = { true, false, false, false }; // 불, 물, 흙, 바람 속성을 가지고 있는가
    private Rigidbody2D rigid;
    Collider2D climbObject; //오르기 명령을 내릴 경우 올라야 할 오브젝트의 collider


    // Start is called before the first frame update
    void Start()
    {
        Property = 0;
        IsJump=false;
        IsMove=true;
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetStats();
        Move();
        Jump();
        if (CanClimb) Climb(climbObject);
    }

    private void SetStats()
    {
        if(Property == 0)
        {
            Weight = 1f;
            Speed = 15f;
            JumpPower = 25f;
        }
        else if(Property == 1)
        {
            Weight = 2f;
            Speed = 10f;
            JumpPower = 20f;
        }
        else if(Property == 2)
        {
            Weight = 4f;
            Speed = 10f;
            JumpPower = 20f;
        }
        else if(Property == 3)
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
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        transform.position = new Vector2(transform.position.x + h * Time.deltaTime * (Speed/Weight), transform.position.y);
    }

    //점프
    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && !IsJump)
        {
            rigid.AddForce(Vector2.up * JumpPower / Weight, ForceMode2D.Impulse);
            IsJump=true;
        }
    }

    private void Climb(Collider2D col)
    {
        float dir = Input.GetAxis("Vertical") * Time.deltaTime * (Speed / Weight);
        if(dir != 0f)
        {
            rigid.gravityScale = 0;
            this.transform.position += new Vector3(0, dir, 0);
            Debug.Log(dir);
        }
    }

    //------------------------------------------Collision 처리-----------------------------------------------
    //collision과 접촉을 한 경우
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider2D = collision.gameObject.GetComponent<Collider2D>();
        if(CanClimb == true)
            collider2D.isTrigger = false;
        else
            collider2D.isTrigger = true;

        if (collision.gameObject.tag == "Ground")
        {
            IsJump=false;
        }
        
    }
    // collision과 접촉 상태를 유지하고 있는경우
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WoodBox")
        {
            float h = Input.GetAxis("Horizontal") * Time.deltaTime * Speed * 0.2f;
            collision.gameObject.transform.position += new Vector3(h, 0, 0);
            transform.position += new Vector3(h, 0, 0);
        }
    }

    //------------------------------------------Trigger 처리-------------------------------------------------
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            CanClimb = true;
            climbObject = collision;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            rigid.gravityScale = 2f;
            CanClimb = false;
        }
    }


    public bool[] IsElementGet { get => isElementGet; set => isElementGet = value; }

}
