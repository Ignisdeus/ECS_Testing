using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Data : MonoBehaviour
{
    [HideInInspector]
    public Ray ray;
    [HideInInspector]
    public RaycastHit hit;
    public float rayLenght = 10f;
    public Transform rayCastPoint;
    [HideInInspector]
    public bool rayCastworking = false;


    private void Start()
    {
        
    }

    public IEnumerator RayCheck()
    {

        yield return new WaitForSeconds(Random.Range(0, 0.5f));


        Vector3 fwd = rayCastPoint.forward;
        Debug.DrawRay(rayCastPoint.position, rayCastPoint.TransformDirection(Vector3.forward) * rayLenght, Color.red);
        if (Physics.Raycast(rayCastPoint.position, rayCastPoint.TransformDirection(Vector3.forward), out hit, rayLenght)) {
            //Debug.DrawRay(x.rayCastPoint.position, x.rayCastPoint.TransformDirection(Vector3.forward) * x.hit.distance, Color.yellow);

            Debug.Log(hit.collider.tag);
        }
        StartCoroutine(RayCheck());

    }
}
