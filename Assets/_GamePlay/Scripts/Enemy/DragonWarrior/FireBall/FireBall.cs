using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeLife;
    private float timeCounter;


    private float dir;


    private Rigidbody2D rigidbody;
    private Animator animator;
    private BoxCollider2D boxCollider;
    

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter >= timeLife)
        {
            OnDestroy();
            timeCounter = 0;
        }
        rigidbody.velocity = new Vector2(speed * dir, 0); 
    }

    public void SetDirection(float value)
    {
        //boxCollider.enabled = true;

        gameObject.SetActive(true);
        dir = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnDestroy();
        }
    }


    private void OnDestroy()
    {
        animator.SetTrigger("death");
        rigidbody.bodyType = RigidbodyType2D.Static;
        boxCollider.enabled = false;
    }



    public void Death()
    {
        rigidbody.bodyType = RigidbodyType2D.Dynamic;

        gameObject.SetActive(false);
        boxCollider.enabled = true;

    }
}
