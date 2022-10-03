using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonWarrior : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private float timePatrol;
    [SerializeField] private float timeIdle;

    private float timePatrolCounter;
    private bool isPatrol;

    private float timeIdleCounter;
    private bool isIdle = true;


    

    private Movement_DW movement;
    private Animator_DW animator;
    private Attack_DW attack;

    private void Awake()
    {
        movement = GetComponent<Movement_DW>();
        movement.enabled = false;

        animator = GetComponent<Animator_DW>();


        attack = GetComponent<Attack_DW>();
        attack.Init(movement.GetDirection());
    }

    private void Update()
    {

        
        if (isIdle)
        {
            animator.Idle(true);

            

            timeIdleCounter += Time.deltaTime;
            if (timeIdleCounter >= timeIdle)
            {
                animator.Idle(false);

                movement.enabled = true;
                isPatrol = true;
                isIdle = false;
                timePatrolCounter = 0;

                attack.enabled = false;
                
            }
        }
        
        if (isPatrol)
        {
            animator.Fly(true);

            timePatrolCounter += Time.deltaTime;
            if(timePatrolCounter > timePatrol)
            {
                animator.Fly(false);

                movement.enabled = false;
                isPatrol = false;
                isIdle = true;
                timeIdleCounter = 0;

                // attack start
                attack.enabled = true;
                attack.Init(movement.GetDirection());
            }
        }
        
        
    }
}
