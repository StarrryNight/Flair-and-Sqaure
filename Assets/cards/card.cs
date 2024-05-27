using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class card
{

    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;
    public string imagePath;
   

    public card()
    {

    }

    public card(int id, string cardName, int cost, int power, string cardDescription, string imagePath)
    {
        this.id = id;
        this.cardName = cardName;
        this.cost = cost;
        this.power = power;
        this.cardDescription = cardDescription;
        this.imagePath = imagePath;
    }


}
