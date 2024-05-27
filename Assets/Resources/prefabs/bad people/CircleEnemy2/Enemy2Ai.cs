using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Ai : MonoBehaviour
{

    Enemy_prop enemy_;
    
    public float seeRange;
    public float speed;
    public Transform player;
    bool alreadyAttacked = false;
    Animator animator;
    public Transform child;
    bool cooldown = false;
    private Transform target;
    private gamemanager gm;
    public string state;
    Vector3 targ;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("game manager").GetComponent<gamemanager>();
        state = "normal";
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, seeRange, LayerMask.GetMask("poeple")))
        {

            if (cooldown == false)
            {
                animator.SetTrigger("attacking");
                cooldown = true;
                
                Invoke("setCooldown", 3);

            }
            else
            {
                animator.SetTrigger("dontmove");
            }

            Debug.Log("sfs");
        }
        else
        {
            animator.SetTrigger("patrolling");
        }

        
        
    }


    void FixedUpdate()
    {


        if (state.Equals("normal"))
        {
            targ = gm.enemyTarget;
            if (!Physics2D.OverlapCircle(transform.position, seeRange - 2, LayerMask.GetMask("poeple")))
            {
                transform.position += transform.up * speed * Time.deltaTime;
            }
        }
        else if (state.Equals("sucking"))
        {
            transform.position += transform.up * speed * 7 * Time.deltaTime;
        }




        if (Vector3.Distance(transform.position, gm.enemyTarget) > 1f)
        {//move if distance from target is greater than 1
            Vector3 dir = targ - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
           
        }

       
        

    }

    private void Awake()
    {   
        child = this.gameObject.transform.GetChild(0);

        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = child.GetComponent<Animator>();
       
    }

    IEnumerator attackPlayer()
    {
        yield return new WaitForSeconds(2);
    }
    void setCooldown()
    {
        cooldown = false;
    }


    public void suck(Vector3 pos)
    {
        state = "sucking";
        targ = pos;

    }

    public void unsuck()
    {
        state = "normal";
    }
}
