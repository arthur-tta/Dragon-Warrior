using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private GameObject[] waypoint;
    [SerializeField] private float speed;

    private int currentWaypointIndex;
    private SpriteRenderer spriteRenderer;


    private Animator animator;
    private ShieldEnemy shieldEnemy;
    private PatrolEnemy patrolEnemy;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shieldEnemy = GetComponent<ShieldEnemy>();
        patrolEnemy = GetComponent<PatrolEnemy>();
        animator = GetComponent<Animator>();
        currentWaypointIndex = Random.Range(0, 2);

    }

    private void Update()
    {
        if (!shieldEnemy.IsShield() && !patrolEnemy.IsPatrol())
        {
            if (Vector2.Distance(waypoint[currentWaypointIndex].transform.position, transform.position) < 0.1f)
            {

                patrolEnemy.SetPatrol(true);
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoint.Length)
                {
                    currentWaypointIndex = 0;
                }
            }
            else
            {
                animator.SetTrigger("run");
                transform.position = Vector2.MoveTowards(transform.position, waypoint[currentWaypointIndex].transform.position, Time.deltaTime * speed);
                if (currentWaypointIndex == 0)
                {
                    spriteRenderer.flipX = false;
                }
                else
                {
                    spriteRenderer.flipX = true;

                }
            }

        }
    }
}
