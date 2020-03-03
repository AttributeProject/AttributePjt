using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushWall : Unmovable
{
    [SerializeField]
    private Sprite bump;
    private bool isDestroyed = false;
    private ParticleSystem particle;

    public bool IsDestroyed { get => isDestroyed; set => isDestroyed = value; }

    protected override void Awake()
    {
        base.Awake();
        particle = GetComponent<ParticleSystem>();
        CanCatchFired = false;
        CanDestroyed = true;
        MaxIndureImpurse = 3f;//temp value
    }

    public override void res_Crush()
    {
        Debug.Log("벽 부숴짐");
        IsDestroyed = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = bump; // 부숴진 모습으로 변경
        if(!particle.IsAlive())
        {
            particle.Play();
        }
    }
}
