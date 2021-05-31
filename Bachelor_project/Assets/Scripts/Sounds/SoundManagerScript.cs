using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip playerSwordEffect, playerDamageEffect, playerDeathEffect;
    static AudioSource audioSrc;
    private float musicVolume = 1f;


    private void Awake()
    {

        
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        playerDeathEffect = Resources.Load<AudioClip>("playerDeathEffect");
        //playerSwordEffect = Resources.Load<AudioClip>("playerSwordEffect");
        playerDamageEffect = Resources.Load<AudioClip>("playerDamageEffect");
        audioSrc = GetComponent<AudioSource>();

        
    }
    private void Update()
    {
        audioSrc.volume = musicVolume;
        

    }


    public static void PlaySound(string clip)
    {

        switch(clip)
        {
            case "playerDeathEffect":
                audioSrc.PlayOneShot(playerDeathEffect);
                break;
           // case "playerSwordEffect":
             //   audioSrc.PlayOneShot(playerSwordEffect);
              //  break;
            case "playerDamageEffect":
                audioSrc.PlayOneShot(playerDamageEffect);
                break;
            
        }
        
        
    }
    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
       



    }
   
}
