using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonGas : Movable
{
    private Vector3 center;
    private float moveSpeed;
    private float rotateSpeed;
    private float timer;
    private int dirX;
    private int dirY;
    private int dirZ;

    // Start is called before the first frame update
    override protected void Awake()
    {
        base.Awake();
        center = transform.position;
        moveSpeed = 1.5f;
        rotateSpeed = 100f;

        dirX = Random.Range(-1, 2);
        dirY = Random.Range(-1, 2);
        dirZ = Random.Range(-1, 2);
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        if(Vector3.Distance(transform.position, center) <= 1f)
        {
            RandomMove();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, center, moveSpeed * Time.deltaTime);
            dirX = Random.Range(-1, 2);
            dirY = Random.Range(-1, 2);
            dirZ = Random.Range(-1, 2);
        }
    }

    override public void res_Fire()
    {
        transform.parent.GetComponent<Mushroom>().PoisonNum -= 1;
        gameObject.SetActive(false);
    }

    void RandomMove()
    {
        if(dirX + dirY == 0)
        {
            dirX = Random.Range(-1, 2);
            dirY = Random.Range(-1, 2);
        }
        if(dirZ == 0)
        {
            dirZ = Random.Range(-1, 2);
        }
        transform.Translate(new Vector3(dirX, dirY, 0f) * moveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, dirZ) * rotateSpeed * Time.deltaTime);
    }
}
