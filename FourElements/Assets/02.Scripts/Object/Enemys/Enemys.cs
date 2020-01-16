using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : Characters
{
    private bool isAggressive; // 선공인가
    private float trackingRange; // 추적범위

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetIsAggressive(bool value)
    {
        isAggressive = value;
    }
    public bool GetIsAggressive()
    {
        return isAggressive;
    }
    public void SetTrackingRange(float value)
    {
        trackingRange = value;
    }
    public float GetTrackingRange()
    {
        return trackingRange;
    }
}
