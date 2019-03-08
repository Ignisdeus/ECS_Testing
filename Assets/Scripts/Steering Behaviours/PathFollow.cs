using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : SteeringBehaviour
{
    [Range(0,20f)]
    public float distance = 2f;
    public Path_Data path;


    int current = 0; 

    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, path.waypoints[current]);
        }
    }
    private void Start()
    {
       GameObject[] target = GameObject.FindGameObjectsWithTag("Path");
        int rnd = Random.Range(0, target.Length);
        path = target[rnd].GetComponent<Path_Data>();
    }

    public override Vector3 Calculate(Boid_Data x)
    {

        float dist = Vector3.Distance(x.target, x.transform.position);

        Vector3 target = path.waypoints[current];
        x.target = target;
        bool ariveFlag = false; 
            if (dist < distance)
            {

                if(path.looped){
                    current = (current + 1) % path.waypoints.Count;
                    target = path.waypoints[current];
                    x.target = target;
                }else{
                    if (current != path.waypoints.Count - 1){
                        current++;
                        target = path.waypoints[current];
                        x.target = target;
                            if(current == path.waypoints.Count){
                        Debug.Log("Trigger");
                                ariveFlag = true;
                            }
                    }

                }
               
               // return x.GetComponent<SeekBehaviour>().Calculate(x);
            }
        int stopAt = path.waypoints.Count; 

        if(!path.looped && current == path.waypoints.Count-1)
        {
            //target = path.waypoints[path.waypoints.Count];
           // x.target = target;
            return x.GetComponent<ArriveBehaviour>().Calculate(x);
        }else{
            return x.GetComponent<SeekBehaviour>().Calculate(x);
        }
        //return Vector3.zero;
    }

}
