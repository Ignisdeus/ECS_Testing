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

    // Update is called once per frame
    void Update()
    {
        

        if(targetLocation){

            float distance = Vector3.Distance(transform.position, target);
            if (distance < distanceCheck){
                target = Vector3.zero;
                TargetLocation(); 

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
