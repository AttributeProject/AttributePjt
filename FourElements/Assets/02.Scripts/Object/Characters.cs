using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : Objects
{
    private float speed; // 속도
    private float jumpPower; // 점프파워
    private int HP; // 체력
    private int property; // 현재속성, -1 = 속성없음, 0 = 불, 1 = 물, 2 = 흙, 3 = 바람
    private bool isJump; // 점프했는가
    private bool canClimb=false;//오를 수 있는가(사다리 등)

    public float Speed { get => speed; set => speed = value; }
    public float JumpPower { get => jumpPower; set => jumpPower = value; }
    public int HP1 { get => HP; set => HP = value; }
    public int Property { get => property; set => property = value; }
    public bool IsJump { get => isJump; set => isJump = value; }
    public bool CanClimb { get => canClimb; set => canClimb = value; }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("click up arrow key");
        }
    }
}
