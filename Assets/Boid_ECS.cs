using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class Boid_ECS : ComponentSystem{
    struct components{
        public Transform pos;
        public Boid_Data boid;
    }

    protected override void OnStartRunning(){
        //foreach (var b in GetEntities<components>()){


            //SteeringBehaviour[] behaviours = b.boid.GetComponents<SteeringBehaviour>();

            //foreach (SteeringBehaviour x in behaviours)
            //{
                //if (x.isActiveAndEnabled)
                //{
                    //b.boid.movement.Add(x);
                //}
            //}

        //}
    }
    public Vector3 SeekForce(Boid_Data x)
    {
        Vector3 desired = x.target - x.transform.position;
        desired.Normalize();
        desired *= x.maxSpeed;
        return desired - x.velocity;
    }
    public Vector3 ArriveForce(Boid_Data x, float slowingDistance = 15.0f)
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
    Vector3 Calculate(Boid_Data x)
    {

        Vector3 force = Vector3.zero;

        foreach (SteeringBehaviour b in x.movement){

            //if (b.isActiveAndEnabled){

                force += b.Calculate(x) * b.weight;
                //Debug.Log(force);
                float f = force.magnitude;
                if (f >= x.maxForce)
                {
                    force = Vector3.ClampMagnitude(x.force, x.maxForce);
                    break;
                }
            //}
        }
       
        return force;
    }
    protected override void OnUpdate(){
        //float vert = Input.GetAxisRaw("Vertical");

        foreach (var b in GetEntities<components>()){


            b.boid.force = Calculate(b.boid);
            b.boid.acceleration = b.boid.force / b.boid.mass;
            b.boid.velocity += b.boid.acceleration * Time.deltaTime;
            b.boid.transform.position += b.boid.velocity * Time.deltaTime;
            
            if(b.boid.velocity.magnitude > float.Epsilon){

                Vector3 tempUp = Vector3.Lerp(b.boid.transform.up, Vector3.up + (b.boid.acceleration * b.boid.banking), Time.deltaTime * 3.0f);
                b.boid.transform.LookAt(b.boid.transform.position + b.boid.velocity, tempUp);

                b.boid.transform.position += b.boid.velocity * Time.deltaTime;
                b.boid.velocity *= (1.0f - (b.boid.damping * Time.deltaTime));

            } 
        }
    }
}
