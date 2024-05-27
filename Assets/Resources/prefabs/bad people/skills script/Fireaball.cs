using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireaball : MonoBehaviour
{   
       string skillName = "fireball";
        string des = "Summons a fireball";
        string key = "1";
    public GameObject ob;
    public GameObject fireball;
    public GameObject parent;
    GameObject obs;
    SpriteRenderer renderer;
    Vector2 size;
    CircleCollider2D box;
    Vector3 size2;
    Vector2 size3;
    SpriteRenderer renderer2;
    public GameObject realFireball;
    Animation anim;
    public Transform parentTrans;


    private void Start()
    {
        // ob = Resources.Load("skill Indi/fireball Ind.") as GameObject;
        //fireball = Resources.Load("prefabs/Skills/firebal") as GameObject;

        
        
    }

    private void FixedUpdate()
    {
        
    }
    public void aim(Vector3 pos) {
        if(GameObject.Find("fireball Ind.(Clone)" )== null){
            Instantiate(ob);
            
            Debug.Log("INstantiated");
            obs = GameObject.Find("fireball Ind.(Clone)");
            obs.transform.position = pos;
            renderer2 = obs.GetComponent<SpriteRenderer>();
            size3 = renderer2.size;
        }
        
        
            obs.transform.position = pos;
        
    }

    public void attack(Vector3 pos)
    {   
        if( GameObject.Find("firebal(Clone)") != null)
        {
            Destroy ( GameObject.Find("firebal(Clone)").gameObject);
        }
        if ( GameObject.Find("fireballParent(Clone)") == null)
        {
            Instantiate(parent);
        }
        obs.transform.position = pos;
       
        
        realFireball = Instantiate(fireball);
        box = realFireball.GetComponent<CircleCollider2D>();
        parentTrans = GameObject.Find("fireballParent(Clone)").transform;
        realFireball.transform.parent = parentTrans;
        parentTrans.position = pos;
        renderer = realFireball.GetComponent<SpriteRenderer>();
        renderer.enabled = false;
        size = renderer.size;
       
        
        float n = size3.x / size.x;
        Debug.Log(n);


        realFireball.transform.localScale = new Vector3(n, n, 1);

        box.radius =(float) 0.5;
        
        renderer.enabled = true;
        anim = realFireball.GetComponent<Animation>();
        anim.Play("fireballFall");
       
        
        
    

       
    }

    public void ds()
    {
        Destroy(realFireball.gameObject);
    }

   public  void dsIn()
    {
        Destroy(obs.gameObject);
    }

   
  
}
