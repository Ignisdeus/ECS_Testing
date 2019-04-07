using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryTimer : MonoBehaviour
{
    [Range(0f,10f)]
    public float timer; 
    void Start()
    {
        Invoke("DestoryObject", timer);
    }

    void DestoryObject(){

        Destroy(gameObject);
    }
}
