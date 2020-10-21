using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class AnimateGirl : MonoBehaviour
{

    Animator animator;
    SpriteRenderer spriteRenderer;

    public int maxSpeed = 5;

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Roll = Animator.StringToHash("Roll");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int upRun = Animator.StringToHash("upRun");

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var distanePerFrame = maxSpeed * Time.deltaTime;
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            move += Vector3.right * distanePerFrame;
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            move += Vector3.left * distanePerFrame;
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            move += Vector3.up * distanePerFrame;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            move += Vector3.down * distanePerFrame;
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
        this.transform.position = this.transform.position + move;
    }
}