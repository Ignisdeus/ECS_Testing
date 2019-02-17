using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class SeekBehaviour : SteeringBehaviour
{



    public override Vector3 Calculate(Boid_Data x)
    {
        Vector3 desired = x.target - x.transform.position;
        desired.Normalize();
        desired *= x.maxSpeed;

        return desired - x.velocity;

        //return Vector3.zero; 
        
    }
}