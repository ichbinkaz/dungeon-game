﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerStats playerHealth;
    
    public Image fillImage;
    private Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        if(slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        float fillValue = PlayerStats.currentHealth / playerHealth.maxHealth;
        if(fillValue <=slider.maxValue/3)
        {
            fillImage.color = Color.yellow;
        }
        else if(fillValue>slider.maxValue/3)
        {
            fillImage.color = Color.red;
        }
        
        slider.value = fillValue;
        

    }
}
