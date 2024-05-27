using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : Item
{   

    
    public Potions(int id, string name, string des, string iconPath)
    {
        this.id = id;
        this.name = name;
        this.description = des;
        this.iconPath = iconPath;
    }
    public override void use()
    {
        
    }

}
