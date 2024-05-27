using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{ Vector3 p;
    public Transform f;
    public Transform pr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p.y = pr.position.y;
        p.x = pr.position.x;
        p.z = -30;
        f.position = p;
    }
}
