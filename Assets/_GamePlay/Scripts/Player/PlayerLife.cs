using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody2D;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private int health = 3;
    [SerializeField] private Text healthText;


    private UIManager uIManager;
    private Vector3 respawnPostion;
    private bool isDie;


    private void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        respawnPostion = transform.position;
    }

    private void Update()
    {
        healthText.text = "X " + health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemy"))
        {
            if (!isDie)
            {
                deathSoundEffect.Play();
                Die();
                isDie = true;
            }
            
        }
        if (collision.gameObject.CompareTag("Check Point"))
        {
            respawnPostion = collision.gameObject.transform.position;
        }
    }
    

    public void Die()
    {
        rigidbody2D.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
    }

    private void ReSpawnPlayer()
    {
        if (health == 1)
        {
            uIManager.GameOver();
        }
        else
        {
            health--;
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            animator.SetTrigger("respawn");
            transform.position = respawnPostion;
            isDie = false;

        }
        
    }
    public void SetRespawnPostion(Vector3 value)
    {
        respawnPostion = value;
    }
}
