using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private GameObject[] listBullet;
    [SerializeField] private float dirX;
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private LayerMask layerPlayer;

    private float attackCounter = Mathf.Infinity;
    



    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        attackCounter += Time.deltaTime;
        if(attackCounter >= attackCooldown && PlayerInSight())
        {
            // Attack
            animator.SetTrigger("attack");
            attackCounter = 0;
        }
    }

    private int FindBullet()
    {
        for (int i = 0; i < listBullet.Length; i++)
        {
            if (!listBullet[i].activeInHierarchy)
                return i;
        }
        return 0;
    }


    private void Attack()
    {
        //Debug.Log("attack");
        
        int i = FindBullet();
        listBullet[i].transform.position = bulletPoint.position;
        listBullet[i].transform.GetComponent<Bullet>().SetDirection(dirX);
        //Debug.Log("Heuy");
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow cube at the transform position
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(6 * dirX, 0, 0), new Vector3(10, 1.5f, 0));
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position + new Vector3(6 * dirX, 0, 0), new Vector3(10, 1.5f, 0),
                                                0, Vector2.left, 0, layerPlayer);
        
        return hit.collider != null;
    }

}
