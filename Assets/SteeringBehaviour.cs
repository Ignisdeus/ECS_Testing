using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringBehaviour : MonoBehaviour
{
    public float weight = 1f;
    public Vector3 force; 

    //[HideInInspector];
    
    public abstract Vector3 Calculate(Boid_Data x);
}
