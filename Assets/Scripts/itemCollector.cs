using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
    public static int scoreValue = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        scoreText.text = "Score: " + scoreValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("apple"))
        {
            Destroy(collision.gameObject);
            scoreValue = scoreValue + 1;
            scoreText.text = "Score: " + scoreValue;
            collectionSoundEffect.Play();
        }
    }

    public void setScoreToZero()
    {
        scoreValue = 0;
    }
}
