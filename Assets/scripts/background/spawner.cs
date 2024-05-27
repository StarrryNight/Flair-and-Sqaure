using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public int spawnCooldown;
    public int cap;
    public GameObject bad;
    GameObject guy;
    public GameObject circle1;
    
    good goode;
    // Start is called before the first frame update
    void Start()
    {
        guy = GameObject.Find("guy");
        goode = guy.GetComponent<good>();
        
        StartCoroutine(coolDown());
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void spawn()
    {   if (transform.childCount < cap)
        {
            if (Random.Range(0, 10) < 9)
            {
                Instantiate(bad, transform.position, transform.rotation, this.transform);
            }
            else {
                Instantiate(circle1, transform.position, transform.rotation, this.transform);
            }
           
        }
    }

    IEnumerator coolDown()
    {
        while (goode.health > 0)
        {
            yield return new WaitForSeconds(spawnCooldown);
            spawn();
        }
    }
}
