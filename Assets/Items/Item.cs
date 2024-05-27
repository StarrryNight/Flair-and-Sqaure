using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
    {

    
    public int id;
    public string name;
    public string description;
    public string iconPath;

    public Item()
    {

    }

    public Item(int id, string name, string description, string iconPath)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.iconPath = iconPath;
        
    }

    public void add()
    {
        if (itemManager.currentItems.Count <= 8)
        {
            itemManager.currentItems.Add(this);
        }
        
    }
    public abstract void use();
}
