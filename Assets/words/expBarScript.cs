using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class expBarScript : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public void setExp(int exp)
    {
        slider.value = exp;
    }
    public void SetMaxExp(int maxExp)
    {
        
        slider.maxValue = maxExp;
        slider.value = 0;
    }
}
