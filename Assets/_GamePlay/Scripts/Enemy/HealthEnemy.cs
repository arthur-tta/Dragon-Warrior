using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private float health;
    public float currentHealth { get; private set; }

    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private ShieldEnemy shieldEnemy;

    private void Start()
    {
        currentHealth = health;
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        shieldEnemy = GetComponent<ShieldEnemy>();
    }

    public void TakeDame(float damage)
    {
        if (!shieldEnemy.IsShield()) {
            shieldEnemy.SetCondition(true);
            if (currentHealth > 0 && !shieldEnemy.CanShield())
            {
                animator.SetTrigger("hit");
                currentHealth = Mathf.Clamp(currentHealth - damage, 0, health);
            }
            
        }
        
    }

    private void Update()
    {
        if (currentHealth == 0)
        {
            StartCoroutine(Death());
        }
    }


    IEnumerator Death()
    {
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
