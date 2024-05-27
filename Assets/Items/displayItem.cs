using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayItem : MonoBehaviour
{

    public List<Item> DisplayItem = new List<Item>();
    public int displayId = 0;
    public int id;
    public string cardName;
    
    public string cardDescription;
    public Sprite path;
    public Text nameText;
    
    public Text descriptionText;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Loaded anim");
        DisplayItem.Add(itemDatabase.itemDatas[displayId]);
        animator = this.GetComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load("card") as RuntimeAnimatorController;
        Debug.Log("Loaded anim");

        id = DisplayItem[0].id;
        Debug.Log("Loaded id");
        cardName = DisplayItem[0].name;
        Debug.Log("Loaded name");


        cardDescription = DisplayItem[0].description;
        //path = Resources.Load<Sprite>(DisplayCard[0].iconPath);

        nameText.text = "" + cardName;
        
        descriptionText.text = "" + cardDescription;
        //Debug.Log(transform.GetChild(1).GetChild(0).gameObject.name);

        //transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = path;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
