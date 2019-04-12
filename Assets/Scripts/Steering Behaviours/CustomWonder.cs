using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomWonder : SteeringBehaviour
{
    public Vector3 target;
    public static float radus = 70f;
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(Vector3.zero, radus);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(boid,1f);
    }*/
    Vector3 boid;
    private void Start() {
        target = Random.insideUnitSphere * (radus);
    }
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
