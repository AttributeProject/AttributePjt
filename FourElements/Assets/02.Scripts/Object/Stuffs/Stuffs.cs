using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuffs : Objects
{
    private bool isMaked; // 소환된 것인가

    public bool IsMaked { get => isMaked; set => isMaked = value; }

    override protected void Awake()
    {
        base.Awake();
        IsMaked = false;
    }

    override protected void Update()
    {
        
    }

 
}
