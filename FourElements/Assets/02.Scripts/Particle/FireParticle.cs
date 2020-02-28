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
        if (other.gameObject.GetComponent<Objects>() != null)
        {
            Debug.Log(other.name + "res_Fire");
            other.gameObject.GetComponent<Objects>().res_Fire();
        }
    }
}
