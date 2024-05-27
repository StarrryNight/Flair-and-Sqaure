using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class good : MonoBehaviour
{
    public HealthBarScript script;

    public int health = 500;

    // Start is called before the first frame update
    void Start()
    {
        script.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {   
        if(health < 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void changeBar(int amount)
    {   
        health += amount;
        script.setHealth((int)health);
    }
}
