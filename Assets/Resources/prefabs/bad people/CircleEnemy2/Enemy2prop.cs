using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2prop : MonoBehaviour
{

    public int health = 500;
    private bool stop = false;
   private GameObject goodguy;
    private GameObject parent;
    private good goode;
    public int damage;
    Animator anim;
    bool ifTake = true;
    GameObject exp2;
     damageManager damageMan;
   
    // Start is called before the first frame update
    void Start()
    {
        goodguy = GameObject.Find("guy");
        goode = goodguy.GetComponent<good>();
       
        parent = this.transform.parent.gameObject;
        anim = GetComponent<Animator>();
             exp2 = Resources.Load("prefabs/bad people/dropXp/exp2") as GameObject;
        damageMan = GameObject.Find("damage manager").GetComponent<damageManager>();
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && stop == false)
        {
            StartCoroutine(wait());
            Debug.Log("Destroy");
            stop = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "goodBullets")
        {
            if (collision.gameObject.name == "firebal(Clone)")
            {

                fireballProp script = collision.gameObject.GetComponent<fireballProp>();
                health -= script.damage;
                damageMan.damageNum(transform.position, script.damage);
               


            }
            else if (collision.gameObject.name == "goodNormalAttack(Clone)")
            {
                goodNormalAttackBulletScript f = collision.gameObject.GetComponent<goodNormalAttackBulletScript>();
                health -= f.damage;
                damageMan.damageNum(transform.position, f.damage);
                
            }

        }
        else if(collision.gameObject.tag == "Player")
        {
            
            goode.changeBar(-damage);
        }
    }

    IEnumerator wait()
    {

        
        anim.SetTrigger("exit");
        yield return new WaitForSeconds((float)(0.5));
        Instantiate(exp2, transform.position,new Quaternion(0,0,0,0));
        Destroy(parent);
        Destroy(this.gameObject);

    }

    public void takeBeamDamgage(int dam)
    {
        if (ifTake)
        {
            health -= dam;
            ifTake = false;
            Invoke("invincibleFrame", 0.5f);
            damageMan.damageNum(transform.position, dam);
            
        }
    }

    void invincibleFrame()
    {
        ifTake = true;
    }

}
