using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPotion : Potions
{
    public healthPotion(int id, string name, string des, string iconPath) : base(id, name, des, iconPath)
    {
    }

    public override void use()
    {
        GameObject.Find("guy").GetComponent<good>().changeBar(100);
    }
}
