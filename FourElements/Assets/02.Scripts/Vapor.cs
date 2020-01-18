using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vapor : Movable
{
    private float moveSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, moveSpeed, 0);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Propeller")
        {
            collision.gameObject.GetComponent<Propeller>().IsWork = true;
        }
        else if(collision.gameObject.tag != "Grass" && collision.gameObject.tag != "Ladder")
        {
            Destroy(this.gameObject);
        }
    }
}
