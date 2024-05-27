using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorScript : MonoBehaviour
{
    Vector3 v32;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        v32 = Input.mousePosition;
        v32.z = 10;
        v32 = Camera.main.ScreenToWorldPoint(v32);
        transform.position = v32;
    }
}
