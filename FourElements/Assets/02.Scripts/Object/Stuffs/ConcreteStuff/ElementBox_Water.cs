using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementBox_Water : Unmovable
{
    [SerializeField]
    private Sprite sprite;

    private bool isOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpen == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
    public bool IsOpen { get => isOpen; set => isOpen = value; }
}
