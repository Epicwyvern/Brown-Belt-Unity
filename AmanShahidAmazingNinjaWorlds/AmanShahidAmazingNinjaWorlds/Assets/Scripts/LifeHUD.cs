using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeHUD : MonoBehaviour
{
    private GameObject[] hearts;
    private int lives = 3;
    public GameObject background;
    void Awake()
    {
        hearts = GameObject.FindGameObjectsWithTag("heart");
    }

    // Update is called once per frame
    public void HurtPlayer()
    {
        Debug.Log("Ouch!");
        lives -= 1;
        hearts[lives].SetActive(false);
        if (lives == 0) {
            background.GetComponent<GameManager>().GameOver();
        }
        
    }

    public void HealPlayer () {
        Debug.Log("Yay!");
        if (lives < 3) {
            hearts[lives].SetActive(true);
            lives += 1;
        }
    }
}
