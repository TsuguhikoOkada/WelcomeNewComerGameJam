using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpot : MonoBehaviour
{
    [SerializeField] GameObject[]  _destroyObjs;

    

    void OnTriggerEnter2D(Collider2D deathCol)
    {

        Destroy(_destroyObjs[0]);

        //DestroyImmediate(_destroyObjs[0],true);
        //Instantiate(_destroyObjs[0]);
    }

    
    
}
