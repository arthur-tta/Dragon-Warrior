using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] listArrow;
    private float attackCounter = Mathf.Infinity;


    private int FindArrow()
    {
        for (int i = 0; i < listArrow.Length; i++)
        {
            if (!listArrow[i].activeInHierarchy)
                return i;
        }
        return 0;
    }


    private void Update()
    {
        attackCounter += Time.deltaTime;

        if(attackCounter >= attackCooldown)
        {
            attackCounter = 0;
            Attack();
        }
    }


    private void Attack()
    {
        int i = FindArrow();
        listArrow[i].transform.position = firePoint.position;
        listArrow[i].GetComponent<Arrow>().Init();
    }

}
