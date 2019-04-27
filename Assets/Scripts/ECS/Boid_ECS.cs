using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class Boid_ECS : ComponentSystem{
    struct components{
        public Transform pos;
        public Boid_Data boid;
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
       

        foreach (var b in GetEntities<components>()){


            
            Boid_Data x = b.boid;

                //tryed making a state machine setup but slowed down performace to 6 fps unknowen reasion
                if (x.action == Boid_Data.Behaviour.formation) {
                    x.GetComponent<Drone_Data>().enemyTag = "";
                    FormUp(x);
                } else if (x.action == Boid_Data.Behaviour.InFormation ) {
                    TenHuh(x);
                } else {
                    Explore(x);
                }
        } 
    }


    void FormUp(Boid_Data x){
        x.GetComponent<Drone_Data>().enabled = false;
        x.GetComponent<CustomWonder>().weight = 0f; 
        x.GetComponent<ArriveBehaviour>().weight =1f;
        x.GetComponent<SeekBehaviour>().weight =0f;
        x.GetComponent<Boid_Data>().target = x.GetComponent<Boid_Data>().formationPosistion; 
        Explore(x);
        float dist = Vector3.Distance(x.transform.position, x.target); 
        if(dist < 2f){
            x.action = Boid_Data.Behaviour.InFormation;
            BeginTheBattle();
        }
        
    } 

    
    void TenHuh(Boid_Data x){
            x.velocity = Vector3.zero; 
            x.transform.LookAt(x.LookAtPos);
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
    bool notStarted = true; 
    void BeginTheBattle(){

        if(notStarted){
            notStarted = false; 
            GameMaster.GM.GetComponent<GameMaster>().BeginFightCommand(); 
        }
       
    } 


}

