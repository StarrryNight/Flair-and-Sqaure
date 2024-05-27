using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystemScript : MonoBehaviour
{
ParticleSystem FX_sparks;
    ParticleSystem.EmissionModule FX_em_sparks;
    ParticleSystem.EmitParams FX_params_sparks;
    // Start is called before the first frame update
    void Start()
    {
        FX_sparks = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void emit(Vector3 a)
    {
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.position = a;
        emitParams.applyShapeToPosition = true;
        FX_sparks.Emit(emitParams, 10);
    }
}
