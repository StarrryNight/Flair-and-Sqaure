using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyAi : MonoBehaviour
{
    Enemy_prop enemy_;
    Attack1 f;
    public float seeRange;
    public float speed;
    public Transform player;
    bool alreadyAttacked = false;
    public string state;
    private gamemanager gm;
    Vector3 targ;
    void Start()
    {
        f = GetComponent<Attack1>();
        enemy_ = GetComponent<Enemy_prop>();
        gm = GameObject.Find("game manager").GetComponent<gamemanager>();
        state = "normal";
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Physics2D.OverlapCircle(transform.position, seeRange, LayerMask.GetMask("poeple")) )
        {
            
            //rotate
            attackPlayer();
        }


        if (state.Equals("normal"))
        {
            transform.position += transform.up * speed * Time.deltaTime;
            targ = gm.enemyTarget;
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
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }







    void attackPlayer()
    {
     
        if (alreadyAttacked != true)
        {
            f.attack();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), enemy_.cooldown);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
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
