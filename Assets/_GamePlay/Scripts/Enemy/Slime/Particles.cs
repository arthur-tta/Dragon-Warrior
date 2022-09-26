using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] private float timeLife;
    private float timeCounter;

    private void Update()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter >= timeLife)
        {
            gameObject.SetActive(false);
            timeCounter = 0;
        }
    }

    public void Init()
    {
        //Debug.Log("hey!");
        gameObject.SetActive(true);
    }
}
