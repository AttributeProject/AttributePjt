using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Grass")
        {
            Grass grass = other.gameObject.GetComponent<Grass>();
            if(!grass.IsFired && !grass.IsBurning)
                other.gameObject.GetComponent<Grass>().res_Fire();
        }
    }
}
