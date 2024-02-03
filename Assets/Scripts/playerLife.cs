using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerLife : MonoBehaviour
{
    public static int livesCount = 3;
    private Animator anim;
    private Rigidbody2D player;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private Image heart1, heart2, heart3;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        player.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("isDead");
        deathSoundEffect.Play();
        livesCount = livesCount -1;
        Invoke("Restart", 1f);


    }

    private void Update()
    {
        switch (livesCount)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;

            case 2:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;

            case 1:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(true);
                break;

            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                Invoke("LoadGameOverScene", 0.5f);
                break;
        }
    }

    private void Restart()
    {
        itemCollector item = new itemCollector();
        item.setScoreToZero();
        SceneManager.LoadScene("Level 1");
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene("Game Over");
        livesCount = 3;
    }

    public void resetLives()
    {
        livesCount = 3;
    }
}
