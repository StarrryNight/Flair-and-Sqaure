using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;

    public void setHealth(int health)
    {
        slider.value = health;
    }
    public void SetMaxHealth(int health)
    {
        
        slider.maxValue = health;
        slider.value = 500;
    }
}
