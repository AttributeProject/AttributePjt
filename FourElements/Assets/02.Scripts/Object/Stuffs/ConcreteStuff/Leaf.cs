using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Movable
{
    private Vector3 first;
    private float range;
    private float speed;
    private Vector3 dir;
    private bool isGround;

    // Start is called before the first frame update
    override protected void Awake()
    {
        base.Awake();
        first = transform.position;
        range = 5f;
        speed = 5f;
        dir = Vector3.right;
        isGround = false;
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        //Debug.Log(Mathf.Abs(first.x - transform.position.x));
        Debug.Log(new Vector2(range / transform.position.x * dir.x, -1));
        if(Mathf.Abs(first.x - transform.position.x) >= range)
        {
            dir = -dir;
            //transform.rotation = Quaternion.Euler(0, -transform.rotation.y + 180, 0);
        }
        if(!isGround)
        {
            transform.Translate(new Vector2(range/ (Mathf.Abs(first.x - transform.position.x)+1) * dir.x, -1) * Time.deltaTime * speed);
        }
    }

    override protected void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
}
