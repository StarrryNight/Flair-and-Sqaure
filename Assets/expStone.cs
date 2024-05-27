using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expStone : MonoBehaviour
{
    public int add;
    expManager expManager;
    GameObject goode;
    bool x = false;
  int  speed =20;
    // Start is called before the first frame update
    void Start()
    {
        expManager = GameObject.Find("exp manager").GetComponent<expManager>();
        goode = GameObject.Find("guy");
    }

    // Update is called once per frame
    void Update()
    {
        if (x)
        {
            transform.position = Vector3.MoveTowards(transform.position, goode.transform.position, speed * Time.deltaTime);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("SAsss");
            expManager.addExp(add);
            Destroy(this.gameObject);
        }

    }

    public void moveTo()
    {
        Debug.Log("ASSSSSSSSSSSSSSS");
        x = true;
       
    }
}
