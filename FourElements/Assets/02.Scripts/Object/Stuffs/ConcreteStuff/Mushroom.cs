using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Unmovable
{
    private int poisonNum;
    private bool isRemove;
    private float respawnTimer;
    private const float respawnTime = 3f;

    public int PoisonNum { get => poisonNum; set => poisonNum = value; }

    // Start is called before the first frame update
    override protected void Awake()
    {
        base.Awake();
        poisonNum = transform.childCount;
        isRemove = false;
        respawnTimer = respawnTime;
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        if(poisonNum == 0)
        {
            isRemove = true;
        }
        if(isRemove)
        {
            respawnTimer -= Time.deltaTime;
            if(respawnTimer <= 0f)
            {
                isRemove = false;
                respawnTimer = respawnTime;
                RespawnPoison();
            }
        }
    }

    private void RespawnPoison()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            poisonNum++;
        }
    }
}
