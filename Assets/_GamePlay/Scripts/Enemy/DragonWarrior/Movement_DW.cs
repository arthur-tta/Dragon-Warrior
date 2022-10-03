using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_DW : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private GameObject[] waypoint;
    [SerializeField] private float speed;

    private int currentWaypointIndex = 1;
    private float dir = 1;


    private Attack_DW attack;

    private void Awake()
    {
        attack = GetComponent<Attack_DW>();
    }

    private void Update()
    {



        if (Vector2.Distance(waypoint[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoint.Length)
            {
                dir = -1;
                currentWaypointIndex = 0;
            }
            else
            {
                dir = 1;
            }

            // quay trai, quay phai
            if (currentWaypointIndex == 0 && (transform.localScale.x > 0))
            {
                dir = -1;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            else if (currentWaypointIndex == 1 && (transform.localScale.x < 0))
            {
                dir = 1;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            }
        }
        else
        {
            // di chuyen den cac diem waypoint
            transform.position = Vector2.MoveTowards(transform.position, waypoint[currentWaypointIndex].transform.position, speed * Time.deltaTime);
        }
        
    }

    public float GetDirection()
    {
        return dir;
    }
    
}
