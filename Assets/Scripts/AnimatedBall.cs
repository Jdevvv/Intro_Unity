using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedBall : MonoBehaviour
{
    public float Speed = 3;

    // private DateTime _nextChangeTime = DateTime.Now;
    // private Vector3 _orientation = Vector3.right;
    // private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Color baseColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseColor = spriteRenderer.color;
    }

    void Update()
    {
        // if (_nextChangeTime < DateTime.Now)
        // {
        //     _orientation = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0).normalized;
        //     _nextChangeTime = DateTime.Now.AddSeconds(1);
        // }

        // transform.position = transform.position + _orientation * (Speed * Time.deltaTime);
        // transform.localEulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(_orientation.y, _orientation.x));
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            spriteRenderer.color = new Color(0.0f, 0.0f, 0.0f, 1f);
        }

        spriteRenderer.color = baseColor;
    }
}