using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardController : MonoBehaviour
{

    public static List<GameObject> cardArray = new List<GameObject>();
    public static List<GameObject> cardParentArray = new List<GameObject>();
    public GameObject goodGuy;
    goodMove goodmove;
    public energyManager energyManager;
    public GameObject decoy;
    public int usings;
    bool selectionCooldowns;
    public good goode;
    bool shrinkCooldown=false;
    public int usingbeam;
    bool checkBeam = true;
    bool destroyBeam =false;
    bool beamDestroy = true;
    GameObject tornadoIndi;
    int usingTornado;
    GameObject tornado;
    Animator anim;
    GameObject beam;
    // Start is called before the first frame update
    void Start()
    {
        goodmove = goodGuy.GetComponent<goodMove>();  
        anim = goode.GetComponent<Animator>();
        tornado = Resources.Load("prefabs/Skills/tornado/tornado") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {   for(int i = 0; i < cardParentArray.Count; i++)
        {
            cardParentArray[i].GetComponent<RectTransform>().anchoredPosition =new Vector3(90 * i -240,40,0) ;
        }
        
        Debug.Log(cardArray.Count);
        
        
    }
    


    public void getParameter(int par)
    {   

       
        int a=    cardArray[par].GetComponent<displayCard>().displayId;
        Debug.Log(a);
        if (a == 0)
        {
            

            if (!goodmove.decoyCooldown)
            {
                bool ifs = energyManager.minusEnergy(2);
                if (ifs)
                {



                    goodmove.molt = true;
                    Instantiate(decoy, goodGuy.transform.position, goodGuy.transform.rotation);
                    goodmove.decoyCooldown = true;
                    setAnim();

                    deselectAnim(par);
                    Invoke("putDecoyCooldown", 10);
                    Invoke("moltTrue", 4);
                    goode.changeBar(100);
                    StartCoroutine(waitAndDestroy(par));




                }
                Debug.Log("ssif");
            }
           
            
            
        }
        else if (a== 1)
        {
            usings = par;
            Debug.Log("ssif2");
           
                deselectAnim(par);
                
              
            
            
            StartCoroutine(s(par));
           
            fireball();
        }
        else if (a == 2)
        {

            if (!shrinkCooldown)
            {
                bool ifs = energyManager.minusEnergy(3);
                if (ifs)
                {
                    setAnim();
                    deselectAnim(par);
                    anim.ResetTrigger("normal");
                    anim.SetTrigger("shrink");
                    
                    goodmove.speed += 7;
                    Invoke("Shrink", 10);
                    Invoke("putShrink", 15);
                    shrinkCooldown = true;
                    StartCoroutine(waitAndDestroy(par));
                }
               
            }
        }

        else if (a == 3)
        {

           
                bool ifs = energyManager.minusEnergy(2);
            if (ifs)
            {
                setAnim();
                selectAnim(par);
                usingbeam = par;
                goodmove.state=("beam");
               
               
                
            }
                

            
        }

        else if (a == 4)
        {
            bool ifs = energyManager.minusEnergy(2);
            if (ifs)
            {
                setAnim();
                deselectAnim(par);
                StartCoroutine(waitAndDestroy(par));
                collect();
            }
        }

        else if (a == 5)
        {
            selectAnim(par);
            goodmove.state = "castingTornado";
            usingTornado = par;
        }

    }
   
    IEnumerator s(int par)
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("select");
        selectAnim(par);
    }
    void fireball()
    {
        goodmove.state = "castingFireball";
    }

    public void moltTrue()
    {
        goodmove.molt = false;
    }



    public void putDecoyCooldown()
    {
        goodmove.decoyCooldown = false;
    }

    void deselectCooldown()
    {
        selectionCooldowns = false;
    }

    public void sendRef(GameObject a)
    {
        beam = a;
    }
    public IEnumerator waitAndDestroy(int q)
    {
        cardArray[q].GetComponent<displayCard>().destroyAnim();
        yield return new WaitForSeconds(1);
        Destroy(cardParentArray[q].gameObject);
        Destroy(cardArray[q].gameObject);
        cardParentArray.RemoveAt(q);
        cardArray.RemoveAt(q);
    }

    public void destroy1()
    {
        
    }

    public static void setAnim()
    {

        if(cardArray.Count>4)
        {   
            for(int i = 0; i < 4; i++)
            {
                cardArray[i].GetComponent<displayCard>().normalAnim();
            }
            for (int i = 4; i < cardArray.Count; i++)
            {
                cardArray[i].GetComponent<displayCard>().comingAnim();
            }
        }
        

        
    }

    public static void selectAnim(int selected)
    {
       
        cardArray[selected].GetComponent<displayCard>().selectedAnim();
    }

    public static void deselectAnim(int a)
    {
        int b;
        b = cardArray.Count-1;
        if(cardArray.Count > 4)
        {
            b = 4;
        }
        for (int i = 0; i < b; i++)
        {
            
                cardArray[i].GetComponent<displayCard>().ssssAnim();
            Debug.Log("deselect");





        }
    }

    public void putShrink()
    {
        shrinkCooldown = false;
        anim.SetTrigger("normal");
    }

    public void Shrink()
    {
        anim.ResetTrigger("shrink");
        anim.SetTrigger("normal");
        goodmove.speed -= 7;
    }
    

public void stopBeam()
    {
       
       StartCoroutine( waitAndDestroy(usingbeam));
        setAnim();
    }

    public void collect()
    {
        Collider2D[] array= Physics2D.OverlapCircleAll(goodGuy.transform.position, 30);
        for(int i = 0; i < array.Length; i++)
        {
            if (array[i].tag == "stone")
            {
                array[i].GetComponent<expStone>().moveTo();
            }
        }
    }


    public void castTornado()
    {
        goodmove.state = "normal";
        int par = usingTornado;
        bool ifs = energyManager.minusEnergy(4);
        if (ifs)
        {
            Destroy(tornadoIndi);
            tornadoIndi = null;
            setAnim();
            deselectAnim(par);
            StartCoroutine(waitAndDestroy(par));
            Vector3 v3 = Input.mousePosition;
            v3.z = 10;
            v3 = Camera.main.ScreenToWorldPoint(v3);
            GameObject t = Instantiate(tornado, v3, new Quaternion(0, 0, 0, 0));
            Destroy(t, 11);
        }
    }

    public void tornadoInd (Vector3 pos)
    {
        if (GameObject.Find("tornadoIndic(Clone)") == null)
        {
            tornadoIndi = Instantiate(Resources.Load("skill Indi/tornadoIndic") as GameObject, pos, new Quaternion(0, 0, 0, 0));
        }
        else
        {
            tornadoIndi.transform.position = pos;
        }
    }

    public void stopTornadoInd()
    {   
        Destroy(tornadoIndi);
        tornadoIndi = null;
        deselectAnim(90);

    }
}




