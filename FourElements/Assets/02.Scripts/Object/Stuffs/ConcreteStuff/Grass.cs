using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : Unmovable
{
    [SerializeField]
    private Sprite firing;
    [SerializeField]
    private Sprite fired;
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

        IsFired = true;
        Weight = transform.localScale.x * transform.localScale.y;
        TimeToBurn = Weight * 2;

        vaporSpawn = transform.GetChild(0).gameObject;
        spawnTimer = Random.Range(0.5f, 1f);
    }
    override protected void Update()
    {
        base.Update();
        if (IsBurning)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = firing;
            CurTimeToBurn += Time.deltaTime;
            if (CurTimeToBurn < TimeToBurn)
            {
                IsBurning = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = fired;
            }
        }
        if (IsWatered)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer < 0 && vaporNum < Weight * 2)
            {
                Instantiate(vapor, vaporSpawn.transform.position, Quaternion.identity);
                vaporNum++;
                spawnTimer = Random.Range(0.5f, 1f);
            }
        }
    }
 
    public override void res_Water()
    {
        Debug.Log("풀 Water Response");
    }

}
