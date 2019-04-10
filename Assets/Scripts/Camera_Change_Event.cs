using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Change_Event : MonoBehaviour
{
    public bool targetLocation;
    public float distanceCheck;
    public Vector3 target; 
    public GameObject targetPoint;
    void Start()
    {
        target = targetPoint.transform.position;

    }
    [Range(0f,10f)]
    public float waitTime;
    
    void Update()
    {
        

        if(targetLocation ) {

            float distance = Vector3.Distance(transform.position, target);
            if (distance < distanceCheck){
                
                target = Vector3.zero;
                Invoke("TargetLocation", waitTime); 

            }

        }
    }

    public GameObject nextCamera, motherShip;
    public GameObject FTLSpawnPoint;
    public GameObject FTL;
    void TargetLocation(){

        nextCamera.SetActive(true);
        Destroy(gameObject);


    } 
}
