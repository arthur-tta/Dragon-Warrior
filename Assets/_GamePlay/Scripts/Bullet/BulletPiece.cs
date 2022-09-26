using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPiece : MonoBehaviour
{
    private float timeLife = 2f;
    private float timeCounter;
    private float dirX = -1;

    private Rigidbody2D rigidbody2D;



    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        

    }

    private void Update()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter >= timeLife)
        {
            gameObject.SetActive(false);
            timeCounter = 0;
        }
    }

    public void SetDirection(float value)
    {
        
        gameObject.SetActive(true);
        dirX = value;
        timeCounter = 0;
        rigidbody2D.AddForce(new Vector2(Random.Range(-5, -20) * dirX, Random.Range(-5, -20) * dirX), ForceMode2D.Force);
    }

}
