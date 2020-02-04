using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : Unmovable
{
    [SerializeField]
    private GameObject obj;
    private bool isWork = false;
    private float spanSpeed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsWork)
        {
            Work();
        }
        else { obj.GetComponent<Electronics>().IsOn = false; }
    }

    private void Work()
    {
        transform.Rotate(0, 0, -spanSpeed);
        obj.GetComponent<Electronics>().IsOn = true;
    }
    public bool IsWork { get => isWork; set => isWork = value; }
}
