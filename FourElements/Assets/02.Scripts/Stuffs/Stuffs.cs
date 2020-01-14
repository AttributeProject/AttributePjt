using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuffs : Objects
{
    private bool isMaked; // 소환된 것인가


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool IsMaked { get => isMaked; set => isMaked = value; }
}
