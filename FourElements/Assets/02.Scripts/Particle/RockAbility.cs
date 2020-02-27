using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAbility : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Stone")
        {
            collision.transform.localScale *= 0.99f;
            if(Player.transform.localScale.x < 7f)
            {
                Player.transform.localScale *= 1.0005f;
            }
            if(Player.gameObject.GetComponent<Player>().Weight < 10f)
            {
                Player.gameObject.GetComponent<Player>().Weight += 0.0005f;
            }
            if(collision.transform.localScale.x + collision.transform.localScale.y < 0.2f)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
