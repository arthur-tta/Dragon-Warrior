using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_DW : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private GameObject[] listFireBall;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float totalShoot;

    private float attackCounter;
    private float shootCounter;

    private bool attack;

    [Header("Fire Point")]
    [SerializeField] private Transform firepoint;
    private float dir;

    [Header("Layer Mask")]
    [SerializeField] private LayerMask layerPlayer;

    private Animator_DW animator;

    private void Awake()
    {
        animator = GetComponent<Animator_DW>();
        
    }

    private void Update()
    {
        if (PlayerInSight())
        {
            attack = true;
        }
        else
        {
            attack = false;
        }

        if (attack)
        {
            attackCounter += Time.deltaTime;
            //Debug.Log("hey");
            if (attackCounter >= attackCooldown && shootCounter < totalShoot)
            {
                Attack();
                Debug.Log("DW attack");
            }
        }

        

        //Debug.Log(PlayerInSight());
    }

    private int FindFireBall()
    {
        for (int i = 0; i < listFireBall.Length; i++)
        {
            if (!listFireBall[i].activeInHierarchy)
                return i;
        }
        return 0;
    }


    private void Attack()
    {
        attackCounter = 0;
        shootCounter++;
        animator.Shoot();

        int i = FindFireBall();
        listFireBall[i].transform.position = firepoint.position;
        listFireBall[i].transform.GetComponent<FireBall>().SetDirection(dir);
    }

    public void Init(float value)
    {
        attack = false;
        shootCounter = 0;
        dir = value;
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position + new Vector3(7 * dir, -1.5f, 0), new Vector3(13, 2, 0),
                                                0, Vector2.left, 0, layerPlayer);

        return hit.collider != null;
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a yellow cube at the transform position
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(7 * dir, -1.5f, 0), new Vector3(13, 2, 0));
    }

    public void SetDirection(float value)
    {
        dir = value;
    }
}
