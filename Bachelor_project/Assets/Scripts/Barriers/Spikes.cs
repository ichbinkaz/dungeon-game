using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();

    }

    private void OnTriggerEnter2D(Collider2D col)
    { 
       
        if (col.CompareTag("Player"))
        {
            Scene scene;
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            ScoreCounter.scoreValue = 0;


        }

       
    }
}
