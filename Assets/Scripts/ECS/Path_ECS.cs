using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class Path_ECS : ComponentSystem
{
    public struct components{
        public Path_Data path; 
    }  
    protected override void OnUpdate()
    {
        foreach (var e in GetEntities<components>()){


            

        }
    }


    void OnDrawGizmos()
    {
        foreach (var e in GetEntities<components>()){
            
            
            for(int i =0; i < e.path.waypoints.Count; i ++){
                int next = (e.path.current + 1) % e.path.waypoints.Count; 
                Gizmos.DrawLine(e.path.waypoints[i], e.path.waypoints[next]);
            }
        }
    }
}
