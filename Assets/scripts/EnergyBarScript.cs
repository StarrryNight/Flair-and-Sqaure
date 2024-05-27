using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarScript : MonoBehaviour
{
    energyManager ener;
    public Slider slider;
    public Text maxText;
    public Text currentText;

    private void FixedUpdate()
    {
       
        if (ener.EnergyState.Equals("add") && ener.currentEnergy<10)
        {   
            ener.currentEnergy += (ener.rate*Time.deltaTime);
            slider.value = ener.currentEnergy;
            currentText.text = (Mathf.Floor(ener.currentEnergy)).ToString() ;
            Debug.Log("adding");
        }


    }

    void Start()
    {
        ener = GameObject.Find("energy manager").GetComponent<energyManager>();
        SetMaxEnergy((int)ener.currentEnergy);
       
    }
    public void setEnergy(int en)
    {
        slider.value = en;
    }
    public void SetMaxEnergy(int en)
    {
        slider.value = en;
        slider.maxValue = 10;
        maxText.text = 10.ToString();
    }
}
