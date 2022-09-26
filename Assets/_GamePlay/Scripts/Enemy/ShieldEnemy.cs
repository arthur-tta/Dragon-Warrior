using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : MonoBehaviour
{
    [Header("Shield Parameters")]
    [SerializeField] private float movementCooldown;
    [SerializeField] private float shieldCooldown;
    [SerializeField] private bool haveShield;

    private bool shield;
    private float shieldCounter;
    private float movementCounter = Mathf.Infinity;
    private bool condition;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (haveShield)
        {
            if (!shield)
            {
                
                movementCounter += Time.deltaTime;
                if (movementCounter >= movementCooldown && condition)
                {    
                    shield = true;
                    movementCounter = 0;
                    animator.SetBool("shield", true);
                }
            }

            if (shield)
            {

                //Debug.Log("Zo");
                shieldCounter += Time.deltaTime;
                if (shieldCounter >= shieldCooldown)
                {
                    shield = false;
                    shieldCounter = 0;
                    animator.SetBool("shield", false);
                    //SetCondition(false);

                }
            }
        }
        SetCondition(false);
    }



    public bool IsShield()
    {
        return shield;
    }

    public void SetCondition(bool state)
    {
        condition = state;
    }

    public bool CanShield()
    {
        return movementCounter >= movementCooldown && haveShield;
    }
}
