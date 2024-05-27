using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public int killCount = 0;
    public Vector3 enemyTarget;
    public GameObject[] skills;
    public bool ifMove = true;
    GameObject itemContainer;
    GameObject cardContainer;
    string current = "card";
    // Start is called before the first frame update
    void Start()
    {
        enemyTarget = GameObject.Find("guy").transform.position;
        itemContainer = GameObject.Find("itemContainerParent");
        cardContainer = GameObject.Find("containerParent");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchContainer()
    {
        Debug.Log(current);
        if(current == "card")
        {
            cardContainer.GetComponent<RectTransform>().position = new Vector3(1442, 90, 0);
           
            itemContainer.GetComponent<RectTransform>().position = new Vector3(442, 90, 0);
            playAnim();
            current = "item";

        }
        else
        {
            cardContainer.GetComponent<RectTransform>().position = new Vector3(442, 90, 0);

            itemContainer.GetComponent<RectTransform>().position = new Vector3(1442, 90, 0);
            playAnim();
            current = "card";


        }
    }

    void playAnim()
    {
        cardContainer.transform.GetChild(0).GetComponent<Animation>().Play();
        itemContainer.transform.GetChild(0).GetComponent<Animation>().Play();
    }

    
}
