using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class displayCard : MonoBehaviour
{

    public List<card> DisplayCard = new List<card>();
  public int displayId=1;
    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;
    public Sprite path;
    public Text nameText;
    public Text costText;
    public Text powerText;
    public Text descriptionText;

    Animator animator;
   
    // Start is called before the first frame update
    void Start()
    {
       DisplayCard.Add(cardDatabase.cardList[displayId]); 
        animator= this.GetComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load("card") as RuntimeAnimatorController;
        id = DisplayCard[0].id;
        cardName = DisplayCard[0].cardName;
        cost = DisplayCard[0].cost;
        power = DisplayCard[0].power;
        cardDescription = DisplayCard[0].cardDescription;
        path = Resources.Load<Sprite>(  DisplayCard[0].imagePath);

        nameText.text = "" + cardName;
        costText.text = "" + cost;
        descriptionText.text = "" + cardDescription;
        Debug.Log(transform.GetChild(1).GetChild(0).gameObject.name);
        transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = path;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectedAnim()
    {
        animator.ResetTrigger("goback");
        animator.ResetTrigger("normal");
        animator.SetTrigger("selected");
    }

    public void normalAnim()
    {
        animator.ResetTrigger("coming");
        animator.SetTrigger("normal");
    }

   
    public void comingAnim()
    {
        animator.SetTrigger("coming");
    }

    public void ssssAnim()
    {
        
        animator.SetTrigger("goback");
    }

    public void destroyAnim()
    {
        animator.SetTrigger("cast");
    }
}
