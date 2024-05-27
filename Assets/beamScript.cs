using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beamScript : MonoBehaviour
{
    bool detect = true;
    Transform goodd;
    damageManager damageManager;
    int dam;
    // Start is called before the first frame update
    void Start()
    {
        goodd = transform.parent;
        InvokeRepeating("waitandactivate", 0.5f, 0.5f);
            damageManager = GameObject.Find("damage manager").GetComponent<damageManager>();
        dam = damageManager.beamDamage;
;    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0,11,0);
        


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (detect)
        {
            if (other.tag == "enemies")
            {
                other.GetComponent<Enemy_prop>().takeBeamDamgage(dam);
               
                
                Debug.Log("enemy1");
            }
            else if (other.tag == "Enemy2")
            {
                other.GetComponent<Enemy2prop>().takeBeamDamgage(dam);
                
                
                Debug.Log("enemy2");
            }

        }

    }

   
}
