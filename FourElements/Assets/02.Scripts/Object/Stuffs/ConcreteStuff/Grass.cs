using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : Unmovable
{
    [SerializeField]
    private Sprite firing;
    [SerializeField]
    private Sprite burned;
    [SerializeField]
    private GameObject vapor;
    private GameObject vaporSpawn;
    private bool isWatered = false;
    private float fireTimer;
    private int vaporNum = 0;
    private float spawnTimer;
    public bool IsWatered { get => isWatered; set => isWatered = value; }

    override protected void Awake()
    {
        base.Awake();
        CanCatchFired = true;
        TimeToBurn = 2f;
        CanDestroyed = false;

        IsBurned = false;
        Weight = transform.localScale.x * transform.localScale.y;
        TimeToBurn = Weight * 2;

        vaporSpawn = transform.GetChild(0).gameObject;
        spawnTimer = Random.Range(5, 10) / 10.0f;
    }
    override protected void Update()
    {
        base.Update();
        if (IsFiring)
        {
            CurTimeToBurn += Time.deltaTime;
            if (CurTimeToBurn >= TimeToBurn)
            {
                IsFiring = false;
                IsBurned = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = burned;
            }
        }
        if (IsWatered)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer < 0 && vaporNum < Weight * 2)
            {
                Instantiate(vapor, vaporSpawn.transform.position, Quaternion.identity);
                vaporNum++;
                spawnTimer = Random.Range(5, 10) / 10.0f;
            }
        }
    }
 
    public override void res_Fire()
    {
        Debug.Log("풀 Fire Response");
        if(!IsBurned && !IsFiring)
        {
            IsFiring = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = firing;
        }
    }
    public override void res_Water()
    {
        Debug.Log("풀 Water Response");
        if(!IsBurned)
        {
            IsFiring = false;
            IsBurned = true;
            IsWatered = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = burned;
        }
    }

}
