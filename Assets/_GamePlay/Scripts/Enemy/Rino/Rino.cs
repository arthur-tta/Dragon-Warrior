using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rino : MonoBehaviour
{

    [Header("Movement Parametters")]
    [SerializeField] private float speed;
    [SerializeField] private float dirX;

    [Header("Layer Mask")]
    [SerializeField] private LayerMask layerPlayer;
    [SerializeField] private LayerMask layerGround;

    [Header("Player")]
    [SerializeField] private Transform player;


    private bool angry;  // true khi nguoi choi trong pham vi tan cong

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //Debug.Log(PlayerInSight());
        if (!angry)
        {
            animator.SetTrigger("idle");
        }
        if (PlayerInSight())
        {
            angry = true;
            //Debug.Log("yes");
        }
        if (angry)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(dirX, 0), 1000, layerGround);
            if(hit.collider != null)
            {
                animator.SetTrigger("run");
                // xac diinh vi tri de di chuyen den

                transform.position = Vector2.MoveTowards(transform.position, hit.point, Time.deltaTime * speed);


                // khi cham tuong thi dung lai
                if (Vector2.Distance(transform.position, hit.point) < 0.5f)
                {
                    angry = false;
                    animator.SetTrigger("hit wall");
                    spriteRenderer.flipX = !spriteRenderer.flipX;
                    dirX = -dirX;
                }
            }
            
            
        }
       
    }

    

    


    private bool PlayerInSight()
    {
        //TODO: Update Rino
        RaycastHit2D hit = Physics2D.BoxCast(transform.position + new Vector3(4 * dirX, 0, 0), new Vector3(7, 1.5f, 0),
                                                0, Vector2.left, 0, layerPlayer);
        return hit.collider != null;
        
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow cube at the transform position
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(4 * dirX, 0, 0), new Vector3(7, 1.5f, 0));
        
    }
}
