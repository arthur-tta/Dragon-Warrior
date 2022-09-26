using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    private float patrolCooldown;
    private float patrolCounter;
    private bool patrol;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (patrol)
        {
            animator.SetTrigger("idle");
            patrolCounter += Time.deltaTime;
            if (patrolCounter >= patrolCooldown)
            {
                patrol = false;
                patrolCounter = 0;
                patrolCooldown = Random.Range(0.5f, 2.0f);
            }
        }
        
    }

    public void SetPatrol(bool state)
    {
        patrol = state;
    }

    public bool IsPatrol()
    {
        return patrol;
    }


}
