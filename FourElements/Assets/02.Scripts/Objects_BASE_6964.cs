using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    private bool isRise; // 물에 뜨는 가
    private bool isFired; // 불이 붙는 가
    private bool isMove; // 움직일 수 있는가
    private bool isMoved; // 움직여질 수 있는가
    private bool isDestroyed; // 파괴될 수 있는가
    private bool isRolling; // 굴러갈 수 있는가
    private float height; // 높이
    private float width; // 너비
    private float weight; // 무게

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsRise { get => isRise; set => isRise = value; }
    public bool IsFired { get => isFired; set => isFired = value; }
    public bool IsMove { get => isMove; set => isMove = value; }
    public bool IsMoved { get => isMoved; set => isMoved = value; }
    public bool IsDestroyed { get => isDestroyed; set => isDestroyed = value; }
    public bool IsRolling { get => isRolling; set => isRolling = value; }
    public float Height { get => height; set => height = value; }
    public float Width { get => width; set => width = value; }
    public float Weight { get => weight; set => weight = value; }

}