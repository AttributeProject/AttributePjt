using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpWind : Unmovable
{
    private float power = 100f;
    // Start is called before the first frame update
    override protected void Awake()
    {
        
    }

    // Update is called once per frame
    override protected void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rd;
        if ((rd = collision.gameObject.GetComponent<Rigidbody2D>()) != null)
        {
            rd.AddForce(transform.up * (power / collision.gameObject.GetComponent<Objects>().Weight));
        }
    }
}
