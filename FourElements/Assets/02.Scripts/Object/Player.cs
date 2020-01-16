using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Characters
{
    private Rigidbody2D rigid;
    Collider2D climbObject; //오르기 명령을 내릴 경우 올라야 할 오브젝트의 collider
    // Start is called before the first frame update
    void Start()
    {
        IsJump=false;
        SetIsMove(true);
        SetWeight(2f);
        Speed=10f;
        JumpPower=10f;
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetKey(KeyCode.Space) && IsJump)
        {
            rigid.AddForce(Vector2.up * JumpPower / GetWeight(), ForceMode2D.Impulse);
            IsJump=true;
        }
    }

    private void Climb(Collider2D col)
    {
        float dir= Input.GetAxis("Vertical") * Time.deltaTime * Speed;
        if(Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.DownArrow) || 
            Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            this.transform.position = new Vector3(col.transform.position.x, this.transform.position.y, 0);
            Debug.Log("얍");
        }
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+ dir, 0);
        Debug.Log("!!");
     
    }
    //------------------------------------------Collision 처리-----------------------------------------------
    //collision과 접촉을 한 경우
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
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
    private void OnTriggerEnter2D(Collider2D collision)
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
            CanClimb = false;
        }
    }
    
}
