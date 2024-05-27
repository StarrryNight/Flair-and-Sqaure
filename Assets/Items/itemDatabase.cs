using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDatabase : MonoBehaviour
{   
    public static List<Item> itemDatas = new List<Item>();
    // Start is called before the first frame update
    void Awake()
    {
        itemDatas.Add(new Potions(12,"asf","asf","asfs"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
