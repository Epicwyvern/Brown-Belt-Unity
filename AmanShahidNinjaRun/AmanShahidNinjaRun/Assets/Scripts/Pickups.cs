using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickups : MonoBehaviour
{
    
    public ParticleSystem PickUp;
    public int score;
    public Text scoreText;

    void Start()
    {
       PickUp.Stop();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Coin")) {
            score++;
            scoreText.text = score.ToString();
            Destroy(other.gameObject);
            PickUp.Play();
        }
    }
}
