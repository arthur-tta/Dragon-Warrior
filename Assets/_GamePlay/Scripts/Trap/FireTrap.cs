using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    //private float delayCounter;
    //private float activeCounter;
    private bool active; // kich hoat khi nguoi choi cham phai
    private bool triggered; // kich hoat khi bay duoc kich hoat



    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private PlayerLife playerLife;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(playerLife != null && active)
        {
            playerLife.Die();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerLife = null;
        }
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerLife = collision.GetComponent<PlayerLife>();
            if (!triggered)
            {
                StartCoroutine(ActivateFireTrap());
            }
            if (active)
            {
                playerLife.Die();
            }
        }
    }

    private IEnumerator ActivateFireTrap()
    {
        triggered = true;

        animator.SetTrigger("active");
        yield return new WaitForSeconds(activationDelay);
        active = true;
        animator.SetTrigger("on");
        yield return new WaitForSeconds(activeTime);
        active = false;
        animator.SetTrigger("idle");

        triggered = false;

    }



}
