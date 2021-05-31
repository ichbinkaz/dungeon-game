using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieSpace : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            Scene scene;
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("Main");
            ScoreCounter.scoreValue = 0;


        }


    }
}
