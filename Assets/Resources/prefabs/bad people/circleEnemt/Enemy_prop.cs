using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_prop : MonoBehaviour
{
   public int health =200 ;
     int attackPower;
    bool ifAttack = false;
   public float cooldown =3;
    Animation anim;
    public Text x;
    public killCountScript b;
    bool stop = false;
    public expManager exp;
    bool ifTake=true;
    public GameObject expMan;
    public damageManager damageMan;
    GameObject exp1;
   
     
    // Start is called before the first frame update
    void Start()
    {
        
        ifAttack = true;
        anim = GetComponent<Animation>();
        x = GameObject.Find("Canvas").transform.Find("killCount").GetComponent<Text>() as Text;
        b= x.GetComponent<killCountScript>();
        expMan = GameObject.Find("exp manager");
        exp = expMan.GetComponent<expManager>() as expManager;
        damageMan = GameObject.Find("damage manager").GetComponent<damageManager>();
        exp1 = Resources.Load("prefabs/bad people/dropXp/exp1") as GameObject;
       


    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && stop==false)
        {
            StartCoroutine(wait());
            Debug.Log("Destroy");
            
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
                damageMan.damageNum(collision.GetContact(0).point, script.damage);
               
                
               
                
            }
            else if(collision.gameObject.name == "goodNormalAttack(Clone)")
            {
                goodNormalAttackBulletScript  f= collision.gameObject.GetComponent<goodNormalAttackBulletScript>();
                health -= f.damage;
                damageMan.damageNum(collision.GetContact(0).point, f.damage);
                
            }

        }
    }

    IEnumerator wait()
    {

        
        b.changeNum();
        anim.Play("circleAnim");
        Instantiate(exp1, transform.position, new Quaternion(0, 0, 0, 0));
        Debug.Log("MADEEE");
        stop = true;
        yield return new WaitForSeconds((float)(0.4));
        
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
