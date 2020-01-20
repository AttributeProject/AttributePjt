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
        if(other.tag == "Grass" && other.gameObject.GetComponent<Grass>().IsBurning)
        {
            other.gameObject.GetComponent<Grass>().IsBurning = false;
            other.gameObject.GetComponent<Grass>().IsFired = true;
            other.gameObject.GetComponent<Grass>().IsWatered = true;
        }
    }
}
