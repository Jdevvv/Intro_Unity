using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class AnimateGirl : MonoBehaviour
{

    Animator animator;
    SpriteRenderer spriteRenderer;

    public float maxSpeed = 0.08F;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            move = Vector3.right * maxSpeed;
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = Vector3.left * maxSpeed;
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            move = Vector3.up * maxSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            move = Vector3.down * maxSpeed;
        }

        animator.SetFloat("Speed", Mathf.Abs(move.magnitude));
        this.transform.position = this.transform.position + (Vector3)move;
    }
}