using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stool : Electronics
{
    [SerializeField]
    private Sprite enable;
    [SerializeField]
    private Sprite disable;
    private bool isUp = true;
    private float moveSpeed = 0.1f;

    public bool IsUp { get => isUp; set => isUp = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsOn)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = enable;
            Work();
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = disable;
        }
    }

    private void Work()
    {
        if(IsUp)
        {
            transform.Translate(0, moveSpeed, 0);
        }
        else
        {
            transform.Translate(0, -moveSpeed, 0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Rail")
           IsUp = !IsUp;
    }
}
