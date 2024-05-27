using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Transform trans;
    GameObject goodguy;
    private good goode;
    public float speed;
    public int damage = 20;
    // Start is called before the first frame update
    void Start()
    {   
        trans = GetComponent<Transform>();
        goodguy = GameObject.FindGameObjectWithTag("Player");
        goode = goodguy.GetComponent<good>();
        StartCoroutine(wait());
        
    }

    // Update is called once per frame
    void Update()
    {
        trans.position += trans.up *speed* Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("dest");
            
            goode.changeBar(-damage);
            Debug.Log(goode.health);
            Destroy(this.gameObject);
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
