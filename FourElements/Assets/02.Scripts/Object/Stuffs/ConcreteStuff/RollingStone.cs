using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingStone : Movable
{
    // Start is called before the first frame update
    override protected void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    protected override void Update()
    {
        //Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity);
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.GetComponent<Objects> () != null)
        {
            Objects obj = col.gameObject.GetComponent<Objects>();
            if (obj.CanDestroyed)
            {
                Debug.Log(col.relativeVelocity.magnitude); // 충격량 출력
                if(col.relativeVelocity.magnitude > 30f)
                    obj.res_Crush();
            }
        }
    }
}
