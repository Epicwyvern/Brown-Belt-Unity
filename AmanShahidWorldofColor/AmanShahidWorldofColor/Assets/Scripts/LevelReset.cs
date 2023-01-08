using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour
{
    public ParticleSystem explosion;
    public GameObject player;

    
    void Start() {
        explosion.Stop();
    }

    void FixedUpdate() {
        explosion.transform.position = player.transform.position;
    }
    
    public void GameOver()
    {
        explosion.Play();
        player.SetActive(false);
        Invoke("Reload", 2);

    }

    void Reload() {
        SceneManager.LoadScene("GO");
    }
}


