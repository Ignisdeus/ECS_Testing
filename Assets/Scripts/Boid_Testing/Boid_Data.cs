using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid_Data : MonoBehaviour
{
    public Vector3 force = Vector3.zero, acceleration = Vector3.zero,  velocity = Vector3.zero, target;
    public float mass = 1;

    [Range(0.0f, 10.0f)]
    public float damping = 0.01f;

    [Range(0.0f, 1.0f)]
    public float banking = 0.1f;
    public float maxSpeed = 5.0f;
    public float maxForce = 10.0f;
    public List<SteeringBehaviour> movement = new List<SteeringBehaviour>();
}
