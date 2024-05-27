using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    
    Enemy_prop enemy_;
    public Transform player;
    bool alreadyAttacked = false;
    public LayerMask Ground, Player;
    Attack1 f;
    public Vector3 walkTarget;
    public float speed;
    public bool canGo, walkPointSet;
    public float walkRange;

    public float AttackRange, seeRange;
    public bool ifSee, ifAttack;
    // Start is called before the first frame update
    void Start()
    {
        f = GetComponent<Attack1>();
        enemy_= GetComponent<Enemy_prop>();
        
    }

    // Update is called once per frame
    void Update()
    {


        
        //correcting the original rotation

        Vector3 dir = player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        //move towards the player
        attackPlayer();
        if (Vector3.Distance(transform.position, player.position) > 1f)
        {//move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

   

    

   

     void attackPlayer()
    {
        transform.LookAt(player);
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
}
