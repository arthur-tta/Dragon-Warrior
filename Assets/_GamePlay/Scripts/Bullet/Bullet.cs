using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float timeLife;

    private float timeCounter;
    private float dirX;

    [Header("Bullet Pieces Parameters")]
    [SerializeField] private GameObject[] listBulletPiece;


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
            Death();
            timeCounter = 0;
        }
        rigidbody2D.velocity = new Vector2(dirX * speed, 0);
    }

    public void SetDirection(float value)
    {
        gameObject.SetActive(true);
        dirX = value;
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
        for(int i = 0; i < listBulletPiece.Length; i++)
        {
            listBulletPiece[i].transform.position = transform.position + new Vector3(0, 0.5f, 0);
            listBulletPiece[i].GetComponent<BulletPiece>().SetDirection(dirX);
        }

    }
}
