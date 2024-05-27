using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goodMove : MonoBehaviour
{
    GameObject cursor;
    public cardController cardController;
    RaycastHit2D hit;
    energyManager energyManager;
    Transform selftrans;
    CharacterController Controller;
    Rigidbody2D body;
    float horizontal;
   public  bool decoyCooldown =false;
    public float dashspeed = 1;
    public Fireaball fireball;
    bool able =true;
    public string state = "normal";
    public NormalAttack nm;
    public decoyCooldownScript dcs;
    bool executable = true;
    char lastKey;
    float lasttime;
    float vertical;
    public float speed =10;
    public Animation animator;
    public float tapSpeed = 2;
   public float dashConstant=3;
   public bool molt=false;
    GameObject usingBeam;
    public GameObject beam;
    float lastDash;
    gamemanager gm;
    public bool ifBeam = false;
    Vector3 v32;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
        selftrans = GetComponent<Transform>();
        animator = GetComponent<Animation>();
        nm = GetComponent<NormalAttack>();
        energyManager = GameObject.Find("energy manager").GetComponent<energyManager>();
        gm = GameObject.Find("game manager").GetComponent<gamemanager>();
        beam = Resources.Load("prefabs/Skills/beam/beam") as GameObject;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        
            if (GameObject.Find("cursor(Clone)") == null)
            {
                cursor = Instantiate(Resources.Load("prefabs/Skills/NormalAttack/cursor")) as GameObject;
            }
           
       
        

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
       
       
            body.velocity = new Vector2(horizontal * speed, vertical * speed);
        if (molt==false)
        {
           
            gm.enemyTarget = transform.position;
            Debug.Log("hisaaaaaaaaaaaaaaaaaaaaaaaaaas");

        }
       

         v32 = Input.mousePosition;
        v32.z = 10;
        v32 = Camera.main.ScreenToWorldPoint(v32);
        Vector3 dir = v32 - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);



        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           
            if (state == "castingTornado")
            {
                
                cardController.stopTornadoInd();

            }
            else if (state == "beam")
            {
                cardController.stopBeam();
                Destroy(usingBeam);
            }
            state = "normal";
            cardController.getParameter(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            
            if (state == "castingTornado")
            {
                
                cardController.stopTornadoInd();

            }
            else if (state == "beam")
            {
                cardController.stopBeam();
                Destroy(usingBeam);
            }
            state = "normal";
            cardController.getParameter(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
           
            if (state == "castingTornado")
            {
               
                cardController.stopTornadoInd();

            }
            else if (state == "beam")
            {
                cardController.stopBeam();
                Destroy(usingBeam);
            }
            state = "normal";
            cardController.getParameter(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            
            if (state == "castingTornado")
            {
               
                cardController.stopTornadoInd();

            }
            else if (state == "beam")
            {
                cardController.stopBeam();
                Destroy(usingBeam);
            }
            state = "normal";
            cardController.getParameter(3);
        }





        //check double tap by comparing reallife press time(w key)

        if (Input.GetKeyDown(KeyCode.W))
        {
            
            
            
            lasttime = Time.time;
            lastKey = 'w';
            
            Debug.Log("sd");
        }

        //check double tap by comparing reallife press time(d key)
       
        if (Input.GetKeyDown(KeyCode.D))
        {
            lasttime = Time.time;
            lastKey = 'd';
        }

        //check double tap by comparing reallife press time(s key)
        
        if (Input.GetKeyDown(KeyCode.S))
        {


            lasttime = Time.time;
            lastKey = 's';
        }

        //check double tap by comparing reallife press time(a key)
        
        if (Input.GetKeyDown(KeyCode.A))
        {


            lasttime = Time.time;
            lastKey = 'a';
        }

        if (Input.GetKeyDown(KeyCode.Space) )
        {
             
           
                float s = Time.time - lasttime;
            
            if(s< tapSpeed)
            {
                state = "dashing";
                lastDash = Time.time;
                dash(s, lastKey);
                Debug.Log("s="+s);
                state = "normal";
                
                
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            state = "castingFireball";
            
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log(state);
            if(state == "normal")
            {
                nm.normalAttack();
            }
            else if (state == "beam")
            {
                Debug.Log("HAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                InvokeRepeating("checkEnergy", 0, 1.2f);
            }
           
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
           
           
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {

            switch (state)
            {
                
                    
                    

                    
                case "castingFireball":
                    
                    Vector3 v3 = Input.mousePosition;
                    v3.z = 10;
                    v3 = Camera.main.ScreenToWorldPoint(v3);

                    fireball.aim(v3);
                    break;

                case "beam":
                        if (ifBeam == false)
                        {

                            ifBeam = true;
                            usingBeam = (Instantiate(beam, transform));

                        }

                    break;

                case "castingTornado":
                    
                        Vector3 v3a = Input.mousePosition;
                        v3a.z = 10;
                        v3a = Camera.main.ScreenToWorldPoint(v3a);
                        cardController.tornadoInd(v3a);
                    

                    break;

            }
            
        }
        

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

            if (state == "castingTornado")
            {
                cardController.stopTornadoInd();
            }
            else if(state == "beam")
            {
                cardController.stopBeam();
                Destroy(usingBeam);
                CancelInvoke();
                
                ifBeam = false;
            }
            state = "normal";
            fireball.dsIn();
            cardController.deselectAnim(69);




        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (state == "castingFireball")
            {
                Vector3 v3 = Input.mousePosition;
                v3.z = 10;
                v3 = Camera.main.ScreenToWorldPoint(v3);
                bool ifs = energyManager.minusEnergy(4);
                if (ifs)
                {
                    fireball.attack(v3);
                    cardController.StartCoroutine(cardController.waitAndDestroy(cardController.usings));

                }
                fireball.dsIn();
               
                state = "normal";
                
                
                
            }

          
            if (state == "normalAttack")
            {
                state = "normal";
            }
            if(state == "beam")
            {
                state = "normal";
                cardController.stopBeam();
                Destroy(usingBeam);
                CancelInvoke();
                Debug.Log("Canceled");
                ifBeam = false;
            }


            if (state == "castingTornado")
            {
                state = "normal";
                cardController.castTornado();
            }
            

            
        }


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            gm.switchContainer();
            
            
        }
    }

   


    void dash(float distance, char direction)
    {

        Debug.Log("Dashed");
        
        animator.Play("dash");
        switch (direction) {

            //change the position of square base on the given direction and distance(tapspeed);
            case 'w':
                
                Vector3 Dashchange= new Vector3(selftrans.position.x,selftrans.position.y + distance*dashConstant, selftrans.position.z);
                Debug.Log(distance);
                float m = Time.time;
                Debug.Log("current =" + selftrans.position + "target=" + Dashchange);
                hit = Physics2D.Raycast  (selftrans.position, Vector3.up, distance *dashConstant,7);
                //Debug.DrawRay(selftrans.position, Vector3.up, Color.green,2);
                //Debug.Log("s" +hit.point);
                if (hit.collider != null)
                {
                    Debug.Log("hit");
                    selftrans.position = Vector3.MoveTowards(selftrans.position,hit.point,dashspeed*Time.deltaTime);
                }
                else
                {
                    selftrans.position = Vector3.MoveTowards(selftrans.position, Dashchange, dashspeed * Time.deltaTime);
                }
                Debug.Log("time:" + (Time.time - m));
                Debug.Log(hit.point);
              
                // move the character:

                break;

            case 's':
               Vector3 Dashchanges = new Vector3(selftrans.position.x, selftrans.position.y - distance * dashConstant, selftrans.position.z);
                hit = Physics2D.Raycast(selftrans.position, -Vector3.up, distance * dashConstant, 7);
                //Debug.DrawRay(selftrans.position, Vector3.up, Color.green,2);
                //Debug.Log("s" +hit.point);
                if (hit.collider != null)
                {
                    Debug.Log("hit");
                    selftrans.position = Vector3.MoveTowards(selftrans.position, hit.point, dashspeed * Time.deltaTime);
                }
                else
                {
                    selftrans.position = Vector3.MoveTowards(selftrans.position, Dashchanges, dashspeed * Time.deltaTime);
                }

                break;

            case 'a':
              Vector3  Dashchangea = new Vector3(selftrans.position.x - distance * dashConstant, selftrans.position.y, selftrans.position.z);
                hit = Physics2D.Raycast(selftrans.position, -Vector3.right, distance * dashConstant, 7);
                //Debug.DrawRay(selftrans.position, Vector3.up, Color.green,2);
                //Debug.Log("s" +hit.point);
                if (hit.collider != null)
                {
                    Debug.Log("hit");
                    selftrans.position = Vector3.MoveTowards(selftrans.position, hit.point, dashspeed * Time.deltaTime);
                }
                else
                {
                    selftrans.position = Vector3.MoveTowards(selftrans.position, Dashchangea, dashspeed * Time.deltaTime);

                }
                    break;
                

            case 'd':
              Vector3  Dashchanged = new Vector3(selftrans.position.x + distance * dashConstant, selftrans.position.y, selftrans.position.z);
                hit = Physics2D.Raycast(selftrans.position, Vector3.right, distance * dashConstant, 7);
                //Debug.DrawRay(selftrans.position, Vector3.up, Color.green,2);
                //Debug.Log("s" +hit.point);
                if (hit.collider != null)
                {
                    Debug.Log("hit");
                    selftrans.position = Vector3.MoveTowards(selftrans.position, hit.point, dashspeed * Time.deltaTime);
                }
                else
                {
                    selftrans.position = Vector3.MoveTowards(selftrans.position, Dashchanged, dashspeed * Time.deltaTime);
                }

                break;




        }
        
    }

    void checkEnergy()
    {
        if (!energyManager.minusEnergy(1))
        {
            Debug.Log("JJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJ");
            state = "normal";
            cardController.stopBeam();
            Destroy(usingBeam);
            CancelInvoke();
            ifBeam = false;
        }
        
    }

    void switchCooldown()
    {
        able = true;

    }
}

    

    

   
