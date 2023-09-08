using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("bullet hit" + other.gameObject.name);
        Destroy(gameObject, 2f);
    }
}