using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int score = 0;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text yourScore;
    [SerializeField] private AudioSource collectSoundEffect ;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            Destroy(collision.gameObject);
            score += 10;
            collectSoundEffect.Play();

            scoreText.text = "Score: " + score;
            yourScore.text = "YOUR SCORE: " + score;
        }
    }
}
