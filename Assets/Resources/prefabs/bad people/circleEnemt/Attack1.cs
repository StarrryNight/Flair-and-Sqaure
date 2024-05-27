using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour
{
    Transform selftrans;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        selftrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void attack()
    {
        Instantiate(bullet, selftrans.position, selftrans.rotation);
    }
}
