using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    public float maxHealth;

    public static float currentHealth;
    private GameManager GM;


    private void Start()
    {
        currentHealth = maxHealth;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    public void DecreaseHealth(float amount)
    {
        SoundManagerScript.PlaySound("playerDamageEffect");
        currentHealth -= amount;
        

        if (currentHealth <= 0.0f)
        {
            SoundManagerScript.PlaySound("playerDeathEffect");
            Die();
            ScoreCounter.scoreValue = 0;

        }

    }

    private void Die()
    {
        Destroy(gameObject);

        Scene scene;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        //GM.Respawn();


    }
    





}
