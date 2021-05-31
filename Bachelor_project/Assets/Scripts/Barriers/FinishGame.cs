using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            Scene scene;
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("Menu");
            ScoreCounter.scoreValue = 0;


        }


    }
}
