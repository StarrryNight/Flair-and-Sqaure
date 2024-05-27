using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardGenertor : MonoBehaviour
{

    public GameObject cardInstance;
    public GameObject cardParent;
    public Canvas canvas;
    bool ifGenerate = true;
    public GameObject container;
    // Start is called before the first frame update
    void Start()
    {
        container = GameObject.Find("card container");
    }

    // Update is called once per frame
    void Update()
    {
        if (ifGenerate && cardController.cardArray.Count<6)
        {
            Debug.Log("safsaffffffffffffffffffffff");
                    ifGenerate = false;
            StartCoroutine(wait());
            cardController.cardParentArray.Add(Instantiate(cardParent, container.transform));
            cardController.cardArray.Add( Instantiate(cardInstance, cardController.cardParentArray[cardController.cardParentArray.Count-1].transform));
                    cardController.cardArray[cardController.cardArray.Count-1].GetComponent<displayCard>().displayId = Random.Range( 0,6);
            cardController.cardParentArray[cardController.cardArray.Count - 1].GetComponent<RectTransform>().anchorMax = new Vector2 (0.5f,0);
            cardController.cardParentArray[cardController.cardArray.Count - 1].GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
            StartCoroutine(waitAndSet());
            
            
            
        }
    }

    IEnumerator wait()
    {
       
        yield return new WaitForSeconds(2);
        ifGenerate = true;
    }

    IEnumerator waitAndSet()
    {
        yield return new WaitForSeconds(0.3f);
        cardController.setAnim();
    }


}
