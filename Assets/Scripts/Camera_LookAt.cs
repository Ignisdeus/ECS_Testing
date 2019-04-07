using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_LookAt : MonoBehaviour
{
    public GameObject target; 
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.LookAt(target.transform);
    }
}
