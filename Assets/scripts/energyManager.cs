using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyManager : MonoBehaviour
{   

    public EnergyBarScript energyBarScript;
    public string EnergyState = "add";
    public float rate = 0.7f;
    public float currentEnergy = 5;
   
    public GameObject notEnoughParent;
    public Canvas canvas;
    public bool minusEnergy(float amount)
    {   if (currentEnergy - amount < 0)
        {
            GameObject parent = Instantiate(notEnoughParent, canvas.transform,false);
           
            
            Destroy(parent, 1);
            return false;
            
        }
        else
        {
            currentEnergy -= amount;
            return true;
        }
        energyBarScript.setEnergy((int)currentEnergy );
    }

}
