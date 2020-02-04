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
        if (other.tag == "Grass" && !other.gameObject.GetComponent<Grass>().FiredDone)
        {
            other.gameObject.GetComponent<Grass> ().NowFired = true;
        }
    }
}
