using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Characters
{
    [SerializeField]
    private GameObject elementsTab;
    [SerializeField]
    private Sprite[] appearance = new Sprite[4];

    private bool[] isElementGet = { true, false, false, false }; // 불, 물, 흙, 바람 속성을 가지고 있는가
    private Rigidbody2D rigid;
    Collider2D climbObject; //오르기 명령을 내릴 경우 올라야 할 오브젝트의 collider


    // Start is called before the first frame update
    void Start()
    {
        Property = 0;
        CanClimb = false;
        IsJump=false;
        IsMove=true;
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetStats();
        
        if (Input.GetKey(KeyCode.Tab))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            elementsTab.SetActive(true);
            ChangeProperty();
        }
        else { 
            elementsTab.SetActive(false);
            if (CanClimb) Climb(climbObject);
            else
            {
                Jump();
            }
            Move();
        }
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
            Weight = 1f;
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
        else if(h > 0)
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
            Physics2D.IgnoreLayerCollision(10, 8, true);
            this.transform.position += new Vector3(0, dir, 0);
        }
    }

    private void ChangeProperty()
    {
        if (IsElementGet[0] == true)
        {
            elementsTab.transform.GetChild(0).gameObject.SetActive(true);
            if(Input.GetKey(KeyCode.LeftArrow))
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
        elementsTab.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 127);
        elementsTab.transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 127);

    }

    //------------------------------------------Collision 처리-----------------------------------------------
    //collision과 접촉을 한 경우
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "WoodBox" || collision.gameObject.tag == "SeedGround")
        {
            IsJump=false;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            rigid.gravityScale = 0f;
            CanClimb = true;
            climbObject = collision;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ElementBox(Water)")
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                IsElementGet[1] = true;
                collision.gameObject.GetComponent<ElementBox_Water>().IsOpen = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            Physics2D.IgnoreLayerCollision(10, 8, false);
            rigid.gravityScale = 2f;
            CanClimb = false;
        }
    }


    public bool[] IsElementGet { get => isElementGet; set => isElementGet = value; }

}
