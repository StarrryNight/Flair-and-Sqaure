using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class decoyCooldownScript : MonoBehaviour
{

    private PlayableDirector pd;

    // Start is called before the first frame update
    void Start()
    {
        pd=GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playCooldown()
    {
        pd.Play();
    }
}
