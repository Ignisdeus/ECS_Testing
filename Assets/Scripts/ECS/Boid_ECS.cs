using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class Boid_ECS : ComponentSystem{
    struct components{
        public Transform pos;
        public Boid_Data boid;
    }

    protected override void OnStartRunning(){}

    /*
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
    }*/
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
       

        foreach (var b in GetEntities<components>()){


            
            Boid_Data x = b.boid;
            //tryed making a state machine setup but slowed down performace to 6 fps unknowen reasion
            if(x.action == Boid_Data.Behaviour.explore){
                Explore(x);
            }else if(x.action == Boid_Data.Behaviour.engage) {
                Explore(x);
            }else{
                Explore(x);
            }

        }
    }

    void Explore(Boid_Data x){
        x.force = Calculate(x);
        x.acceleration = x.force / x.mass;
        x.velocity += x.acceleration * Time.deltaTime;
        x.transform.position += x.velocity * Time.deltaTime;

        if (x.velocity.magnitude > float.Epsilon) {

            Vector3 tempUp = Vector3.Lerp(x.transform.up, Vector3.up + (x.acceleration * x.banking), Time.deltaTime * 3.0f);
            x.transform.LookAt(x.transform.position + x.velocity, tempUp);

            x.transform.position += x.velocity * Time.deltaTime;
            x.velocity *= (1.0f - (x.damping * Time.deltaTime));

        }

        x.currentTime += Time.deltaTime;

        if (x.currentTime > x.rayCastTimer) {
            x.currentTime = 0f;

        }
    }


}

