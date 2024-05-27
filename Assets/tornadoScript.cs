using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tornadoScript : MonoBehaviour
{
    float radius;
    List<Collider2D> li = new List<Collider2D>();
    Animator s;
    bool dos = true;
    // Start is called before the first frame update
    void Start()
    {
        radius = GetComponent<CircleCollider2D>().radius;
        Invoke("exitt", 10);
        Invoke("gets", 9.5f);
        s= GetComponent<Animator>();
        s.runtimeAnimatorController = Resources.Load("prefabs/Skills/tornado/tornadoCon") as RuntimeAnimatorController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dos){
            if (collision.tag == "Enemy2")
            {
                if (!li.Contains(collision))
                {
                    collision.transform.parent.GetComponent<Enemy2Ai>().suck(transform.position);
                    Debug.Log("addedb");
                    li.Add(collision);
                }

            }
            else if (collision.tag == "enemies")
            {
                if (!li.Contains(collision))
                {
                    collision.GetComponent<NewEnemyAi>().suck(transform.position);
                    Debug.Log("addedb");
                    li.Add(collision);
                }

            }
        }
       
    }


    void exitt()
    {
        s.SetTrigger("fade");
       for(int i= 0; i < li.Count; i++)
        {
           
                if ( !(li[i]== null) &&li[i].tag == "Enemy2" )
                {
                    li[i].transform.parent.GetComponent<Enemy2Ai>().unsuck();
                    Debug.Log("un;");
                }

                else if (!(li[i]== null) && li[i].tag == "enemies" )
                {
                    li[i].GetComponent<NewEnemyAi>().unsuck();
                    Debug.Log("un;");


                }
           
          
           
        }
       

    }

    void gets()
    {
        dos = false;
        
    }

}
