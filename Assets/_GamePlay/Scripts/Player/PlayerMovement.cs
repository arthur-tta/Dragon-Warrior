using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    

    // Animator
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float dirX;
    private BoxCollider2D boxCollider2D;

    private enum MovementState { idle, run, jump, attack }
    private MovementState state = MovementState.idle;


    // Attack
    private bool isAttack;

    [SerializeField] private LayerMask layerGround;

    [Header("Movement Parametters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D rigidbody2D;
    private int countJump;

    [SerializeField] private AudioSource jumpSoundEffect;


    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rigidbody2D.velocity = new Vector2(dirX * speed, rigidbody2D.velocity.y);

        if(isGrounded())
        {
            countJump = 2;
        }

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow)) && countJump > 0)
        {
            jumpSoundEffect.Play();
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            countJump--;
        }//else if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow)) && countJump == 0 && isGrounded()) 
        //{
        //    jumpSoundEffect.Play();
        //    rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        //}


        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            state = MovementState.run;
            spriteRenderer.flipX = false;
        }else if (dirX < 0f)
        {
            state = MovementState.run;
            spriteRenderer.flipX = true;

        }
        else
        {
            state = MovementState.idle;
        }

        if(rigidbody2D.velocity.y > 0.1f)
        {
            state = MovementState.jump;
            


        }
        else if(rigidbody2D.velocity.y < -0.1f)
        {
            state = MovementState.jump;
        }

        if (isAttack)
        {
            state = MovementState.attack;
            isAttack = false;
        }

        animator.SetInteger("state", (int)state);

    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, layerGround);
    }

    
}
