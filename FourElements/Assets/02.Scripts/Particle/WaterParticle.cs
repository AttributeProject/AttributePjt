using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParticle : MonoBehaviour
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
        if (other.tag == "SeedGround")
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
        if(other.tag == "Grass" && other.gameObject.GetComponent<Grass>().NowFired)
        {
            other.gameObject.GetComponent<Grass>().NowFired = false;
            other.gameObject.GetComponent<Grass>().FiredDone = true;
            other.gameObject.GetComponent<Grass>().IsWatered = true;
        }
    }
}
