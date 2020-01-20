using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    private int nowProperty;
    private ParticleSystem[] ps = new ParticleSystem[4];
    private bool isPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < ps.Length; i++)
        {
            ps[i] = transform.GetChild(i).GetComponent<ParticleSystem>();
            ps[i].Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        nowProperty = Player.GetComponent<Player>().Property;
        if (Input.GetKey(KeyCode.LeftShift) && !isPlay)
        {
            ps[nowProperty].Play(true);
            isPlay = true;
        }
        if(!Input.GetKey(KeyCode.LeftShift))
        {
            ps[nowProperty].Stop(true, ParticleSystemStopBehavior.StopEmitting);
            isPlay = false;
        }
    }
}
