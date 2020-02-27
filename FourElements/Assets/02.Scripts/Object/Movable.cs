using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : Stuffs
{
    private bool isRolling; // 굴러갈 수 있는가

    public bool IsRolling { get => isRolling; set => isRolling = value; }
    // Start is called before the first frame update
    override protected void Awake()
    {
        base.Awake();
        isRolling = false;
    }

    // Update is called once per frame
    override protected void Update()
    {
        
    }
}
