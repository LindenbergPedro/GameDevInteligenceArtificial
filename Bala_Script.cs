using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_Script : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
