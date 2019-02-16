using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class ArriveBehaviour : SteeringBehaviour
{

    public float slowingDistance = 15.0f;
    public override Vector3 Calculate(Boid_Data x)
    {
        Vector3 toTarget = x.target - x.transform.position;

        float distance = toTarget.magnitude;
        if (distance < 0.1f)
        {
            return Vector3.zero;
        }
        float ramped = x.maxSpeed * (distance / slowingDistance);

        float clamped = Mathf.Min(ramped, x.maxSpeed);
        Vector3 desired = clamped * (toTarget / distance);

        return desired - x.velocity;
    }
}
