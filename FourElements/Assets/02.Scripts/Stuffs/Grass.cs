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
    private bool nowFired = false;
    private bool firedDone = false;
    private bool isWatered = false;
    private float fireTimer;
    private int vaporNum = 0;
    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        IsFired = true;
        Weight = transform.localScale.x * transform.localScale.y;
        FireTime = Weight * 2;
        fireTimer = FireTime;

        vaporSpawn = transform.GetChild(0).gameObject;
        spawnTimer = Random.Range(0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(NowFired)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = firing;
            fireTimer -= Time.deltaTime;
            if(fireTimer < 0)
            {
                NowFired = false;
                FiredDone = true;
            }
        }
        else if(FiredDone)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = fired;
        }
        if(IsWatered)
        {
            spawnTimer -= Time.deltaTime;
            if(spawnTimer < 0 && vaporNum < Weight*2)
            {
                Instantiate(vapor, vaporSpawn.transform.position, Quaternion.identity);
                vaporNum++;
                spawnTimer = Random.Range(0.5f, 1f);
            }
        }
    }
    public bool NowFired { get => nowFired; set => nowFired = value; }
    public bool FiredDone { get => firedDone; set => firedDone = value; }
    public bool IsWatered { get => isWatered; set => isWatered = value; }
}
