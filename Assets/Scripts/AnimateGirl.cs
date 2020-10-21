using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class AnimateGirl : MonoBehaviour
{

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;

    public int maxSpeed = 5;

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Roll = Animator.StringToHash("Roll");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int upRun = Animator.StringToHash("upRun");

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var maxDistancePerFrame = maxSpeed;
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            move += Vector3.right * maxDistancePerFrame;
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            move += Vector3.left * maxDistancePerFrame;
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            move += Vector3.up * maxDistancePerFrame;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            move += Vector3.down * maxDistancePerFrame;
        }

        if (animator.GetBool(Roll)) animator.ResetTrigger(Roll);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger(Roll);
        }

        if (animator.GetBool(Jump)) animator.ResetTrigger(Jump);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger(Jump);
        }

        animator.SetBool(upRun, Input.GetKey(KeyCode.UpArrow));

        animator.SetFloat(Speed, move.magnitude * 10f);
        rigidbody2D.velocity = move;
    }
}

