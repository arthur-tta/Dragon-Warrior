using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Header ("Arrow Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float timeLife;
    [SerializeField] private int dirX;
    [SerializeField] private int dirY;
    private float timeCounter;

    private Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= timeLife)
        {
            Death();
            timeCounter = 0;
        }
        rigidbody2D.velocity = new Vector2(dirX * speed, dirY * speed);
    }

    public void Init()
    {
        gameObject.SetActive(true);
        timeCounter = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Ground"))
        {
            Death();
        }
    }

    private void Death()
    {
        gameObject.SetActive(false);
    }
}
