using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedBall : MonoBehaviour
{
    public float Speed = 3;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer otherSpriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            otherSpriteRenderer = coll.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = otherSpriteRenderer.color;
        }
    }

}