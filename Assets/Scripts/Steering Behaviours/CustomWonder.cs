using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomWonder : SteeringBehaviour
{
    Vector3 target;
    public float radus = 70f;
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(Vector3.zero, radus);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(boid,1f);
    }*/
    Vector3 boid; 
    public override Vector3 Calculate(Boid_Data x){
        boid = x.target;
        float dist = Vector3.Distance(x.transform.position, target);
        
        if(dist < 20){
            
            target = Random.insideUnitSphere * (radus);
            x.target = target;
        }
       return x.GetComponent<SeekBehaviour>().Calculate(x);
    }
}
