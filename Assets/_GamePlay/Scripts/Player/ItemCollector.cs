using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int score = 0;

    [SerializeField] private Text scoreText;
    [SerializeField] private AudioSource collectSoundEffect ;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            Destroy(collision.gameObject);
            score++;
            collectSoundEffect.Play();

            scoreText.text = "Score: " + score;
        }
    }
}
