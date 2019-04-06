using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presue : SteeringBehaviour
{
    public Boid_Data target;

    Vector3 targetPos;
    private void Start()
    {
        target = GetComponent<Boid_Data>(); 
    }
    public override Vector3 Calculate(Boid_Data x)
    {
        if(target != null){
            float dist = Vector3.Distance(target.transform.position, x.transform.position);
            float time = dist / x.maxSpeed;

            targetPos = target.transform.position + (target.velocity * time);

            return x.GetComponent<SeekBehaviour>().Calculate(x);
        }else{

            weight = 0;
            GetComponent<CustomWonder>().weight = 1;
            GetComponent<Boid_Data>().action = Boid_Data.Behaviour.explore;
            return Vector3.zero;
        }


    }
}
