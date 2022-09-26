using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rino : MonoBehaviour
{
    
    [SerializeField] private float delay;
    [SerializeField] private float speed;
    private float timeCounter = Mathf.Infinity;

    private Vector3[] directions;
    [SerializeField] private float dirX;
    [SerializeField] private LayerMask layerPlayer;
    [SerializeField] private LayerMask layerGround;
    private bool run;


    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (run)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(dirX, 0), 1000, layerGround);
            //Debug.Log(hit.point);
            if (Vector2.Distance(transform.position, hit.transform.position) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, hit.transform.position, Time.deltaTime * speed);
                Debug.Log("move");
            }
            else
            {
                run = false;
                spriteRenderer.flipX = !spriteRenderer.flipX;
                dirX = -dirX;
            }
        }
        else
        {
            timeCounter += Time.deltaTime;
            if (timeCounter >= delay)
            {
                //Debug.Log("hey");
                if (PlayerInSight())
                {
                    timeCounter = 0;
                    run = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            run = false;
        }
    }



    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position + new Vector3(3 * dirX, 0, 0), new Vector3(5, 1.5f, 0),
                                                0, Vector2.left, 0, layerPlayer);

        return hit.collider != null;
    }
    private bool PlayerBehindSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position + new Vector3(1 * -dirX, 0, 0), new Vector3(1, 1.5f, 0),
                                                0, Vector2.left, 0, layerPlayer);

        return hit.collider != null;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow cube at the transform position
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(3 * dirX, 0, 0), new Vector3(5, 1.5f, 0));
        Gizmos.DrawWireCube(transform.position + new Vector3(1 * -dirX, 0, 0), new Vector3(1, 1.5f, 0));
    }
}
