using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class Drone_ECS : ComponentSystem
{
    struct components
    {
        public Drone_Data drone; 
    }

    protected override void OnUpdate(){


        foreach (var d in GetEntities<components>()) {
            // raycast looking for a badGuy :) 

            Drone_Data x = d.drone;

            if (!x.rayCastworking){
                x.rayCastworking = true; 
                x.StartCoroutine(x.GetComponent<Drone_Data>().RayCheck());

            } 
        } 
    }

}
