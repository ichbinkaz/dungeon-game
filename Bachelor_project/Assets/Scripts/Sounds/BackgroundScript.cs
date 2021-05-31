using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScript : MonoBehaviour
{


    static AudioSource audioSrc;
    float musicVolume = 1f;



    private void Awake()
    {

        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {

        audioSrc = GetComponent<AudioSource>();
        


    }


    private void Update()
    {
        audioSrc.volume = musicVolume;
        
    }

    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
       

    }
    
}
