using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementBox_Water : Unmovable
{
    [SerializeField]
    private Sprite sprite;

    private bool isOpened = false;

    protected override void Awake()
    {
        base.Awake();
        CanCatchFired = false;
        CanDestroyed = false;
    }

    public override void res_UpArrow()
    {
        //바뀌는거
        Debug.Log("속성상자 UpArrow Response");
        if (!isOpened)
        {
            Debug.Log("속성상자 OPEN");
            //속성상자 열리는 이벤트
            IsOpened = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().IsElementGet[1] = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }
        else
        {
            Debug.Log("속성상자 이미 열려있음");
        }
    }
    public bool IsOpened { get => isOpened; set => isOpened = value; }
}
