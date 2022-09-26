using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Animator animator;
    private PlayerLife playerLife;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("start");
            playerLife = collision.gameObject.GetComponent<PlayerLife>();
            playerLife.SetRespawnPostion(transform.position);
        }
    }
}
