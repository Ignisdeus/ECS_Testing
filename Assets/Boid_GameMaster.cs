using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid_GameMaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){

        for(int i =0; i < BoidCount; i ++){

            Instantiate(boid, transform.position, Quaternion.identity);
        }
        
    }

    public int BoidCount;
    public GameObject boid; 
}
