using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public void restartGame()
    { 
        itemCollector item = new itemCollector();
        item.setScoreToZero();
        playerLife player = new playerLife();
        player.resetLives();
        SceneManager.LoadScene("Level 1");
        BGmusic.instance.GetComponent<AudioSource>().Play();
    }
}
