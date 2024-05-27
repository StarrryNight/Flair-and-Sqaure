using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beamParentScript : MonoBehaviour
{
    // Start is called before the first frame update
    Transform goodd;
    // Start is called before the first frame update
    void Start()
    {
        goodd = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(goodd.position.x, goodd.position.y, goodd.position.z);
    }
}
