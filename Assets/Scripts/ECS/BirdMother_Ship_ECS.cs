using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class BirdMother_Ship_ECS : ComponentSystem
{
    struct components
    {
        public Transform pos;
        public Boid_Data boid;
        public MotherShip_Data ship; 
    }
    
    protected override void OnUpdate(){

        foreach (var b in GetEntities<components>()){
            Boid_Data x = b.boid; 
            if(x.action == Boid_Data.Behaviour.explore){
                MotherShipSetUp(b.ship); 
            }
        }
    }
    
    void MotherShipSetUp(MotherShip_Data x){

        x.GetComponent<PathFollow>().enabled = false;
        x.GetComponent<SeekBehaviour>().weight = 1f;
        x.GetComponent<Boid_Data>().target = Vector3.zero;
        float dist = Vector3.Distance(x.transform.position, Vector3.zero);
        
        if(dist < x.distFromCenter){
            x.GetComponent<PathFollow>().enabled = true;
            x.GetComponent<SeekBehaviour>().weight = 0f;
            x.GetComponent<PathFollow>().weight = 1f;
            x.GetComponent<Boid_Data>().action = Boid_Data.Behaviour.run;
            SpawnCombatBoid(x);

        } 
    } 
    void SpawnCombatBoid(MotherShip_Data x){
                x.StartCoroutine(x.Spawn());
    }
}
