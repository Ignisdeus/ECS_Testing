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
    int spawnedShips = 0; 
    protected override void OnUpdate(){

        foreach (var b in GetEntities<components>()){

            if(b.ship.combat){
                //b.boid.GetComponent<PathFollow>().enabled=true;
                b.boid.GetComponent<ArriveBehaviour>().weight = 0f;
                b.boid.GetComponent<PathFollow>().weight = 1f;
                if(spawnedShips < 1){
                    Debug.Log("spawning");
                    SpawnCombatBoid(b.ship);
                }
 
            } else{
                b.boid.GetComponent<PathFollow>().weight = 0f;
                b.boid.GetComponent<ArriveBehaviour>().weight = 1f;
                float dist = Vector3.Distance(Vector3.zero, b.pos.transform.position);

                if(dist < 50f){
                    int pathNo = b.boid.GetComponent<PathFollow>().path.waypoints.Count;
                    b.boid.GetComponent<PathFollow>().current = Random.Range(0, pathNo);
                    b.ship.combat = true;

                }
            } 
        }
    }

    void SpawnCombatBoid(MotherShip_Data x){


        x.StartCoroutine(x.Spawn());
        


    }
}
