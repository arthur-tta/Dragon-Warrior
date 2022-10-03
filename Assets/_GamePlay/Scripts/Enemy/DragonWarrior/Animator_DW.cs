using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_DW : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Run()
    {
        animator.SetTrigger("run");
    }

    public void Idle(bool value)
    {
        animator.SetBool("idle", value);
    }

    public void Fly(bool value)
    {
        animator.SetBool("strike", value);
    }

    public void Shoot()
    {
        animator.SetTrigger("shoot");
    }
}
