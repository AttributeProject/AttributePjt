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
        if (other.gameObject.GetComponent<Grass>() != null)
        {
            other.gameObject.GetComponent<Grass>().res_Fire();
        }
    }
}
