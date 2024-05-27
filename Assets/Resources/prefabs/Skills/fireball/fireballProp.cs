using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballProp : MonoBehaviour
{
    public int damage;
    CircleCollider2D col;
    damageManager damageManager;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
        StartCoroutine(wait());
        damageManager = GameObject.Find("damage manager").GetComponent<damageManager>();
        damage = damageManager.fireballDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator wait()
    {

        col.enabled = false;

        yield return new WaitForSeconds((float)0.75);
        col.enabled = true;
        yield return new WaitForSeconds((float)0.5);
        Destroy(col.gameObject);

    }

    


}
