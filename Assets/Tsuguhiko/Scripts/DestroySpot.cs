using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpot : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D deathCol)
    {
        Destroy(deathCol.gameObject);
    }
}