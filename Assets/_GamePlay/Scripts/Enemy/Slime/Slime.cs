using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [Header ("Movement Parameters")]
    [SerializeField] private GameObject[] waypoint;
    [SerializeField] private float speed;

    private int currentWaypointIndex;
    private SpriteRenderer spriteRenderer;

    [Header("Particles Parameters")]
    [SerializeField] private GameObject[] listParticles;
    [SerializeField] private float particlesCooldown;

    private float particlesCounter;




    //Componment
    private Animator animator;
    private ShieldEnemy shieldEnemy;
    private PatrolEnemy patrolEnemy;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        shieldEnemy = GetComponent<ShieldEnemy>();
        patrolEnemy = GetComponent<PatrolEnemy>();
        currentWaypointIndex = Random.Range(0, 2);
    }

    private int FindParticles()
    {
        for (int i = 0; i < listParticles.Length; i++)
        {
            if (!listParticles[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void Particles() {
        int i = FindParticles();
        //Debug.Log(i);
        listParticles[i].transform.position = new Vector3(transform.position.x, transform.position.y - 0.53f, transform.position.z);
        listParticles[i].GetComponent<Particles>().Init();
    }


    private void Update()
    {
        particlesCounter += Time.deltaTime;
        if(particlesCounter >= particlesCooldown)
        {
            Particles();
            particlesCounter = 0;
        }

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
