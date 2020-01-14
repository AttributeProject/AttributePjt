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

    public void SetIsRise(bool value)
    {
        isRise = value;
    }
    public bool GetIsRise()
    {
        return isRise;
    }
    public void SetIsFired(bool value)
    {
        isFired = value;
    }
    public bool GetIsFired()
    {
        return isFired;
    }
    public void SetIsMove(bool value)
    {
        isMove = value;
    }
    public bool GetIsMove()
    {
        return isMove;
    }
    public void SetIsMoved(bool value)
    {
        isMoved = value;
    }
    public bool GetIsMoved()
    {
        return isMoved;
    }
    public void SetIsDestroyed(bool value)
    {
        isDestroyed = value;
    }
    public bool GetIsDestroyed()
    {
        return isDestroyed;
    }
    public void SetIsRolling(bool value)
    {
        isRolling = value;
    }
    public bool GetIsRolling()
    {
        return isRolling;
    }
    public void SetHeight(float value)
    {
        height = value;
    }
    public float GetHeight()
    {
        return height;
    }
    public void SetWidth(float value)
    {
        width = value;
    }
    public float GetWidth()
    {
        return width;
    }
    public void SetWeight(float value)
    {
        weight = value;
    }
    public float GetWeight()
    {
        return weight;
    }

}
