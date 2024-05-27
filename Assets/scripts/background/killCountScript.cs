using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class killCountScript : MonoBehaviour
{ gamemanager gm;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("game manager").GetComponent<gamemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeNum()
    {
        gm.killCount++;
       this.GetComponent<UnityEngine.UI.Text>().text = "kill count : " + gm.killCount;
    }
}
