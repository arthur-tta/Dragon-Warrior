using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    private float attackCounter;



    [Header ("Collider Paramaters")]
    [SerializeField] private float colliderDistance;
    private BoxCollider2D boxCollider2D;



    [SerializeField] private LayerMask layerGround;
    [SerializeField] private LayerMask layerEnemy;

    private Animator animator;

    private HealthEnemy healthEnemy;
    private float dirX = 1;

    private void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        attackCounter += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && isGrounded() && attackCounter >= attackCooldown)
        {
            animator.SetTrigger("attack");
            attackCounter = 0;
        }
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            dirX = Input.GetAxisRaw("Horizontal");
        }
    }

    private bool EnemyInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position + new Vector3(1.5f * dirX, -0.3f, 0), new Vector3(1.5f, 1.5f, 0),
                                                0, Vector2.left, 0, layerEnemy);
        if(hit.collider != null)
        {
            healthEnemy = hit.transform.GetComponent<HealthEnemy>();
        }
        return hit.collider != null;
    }

    private void Attack()
    {
        if (EnemyInSight())
        {
            healthEnemy.TakeDame(damage);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, layerGround);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow cube at the transform position
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(1.5f * dirX, -0.3f, 0) , new Vector3(1.5f, 1.5f, 0));
    }


}
