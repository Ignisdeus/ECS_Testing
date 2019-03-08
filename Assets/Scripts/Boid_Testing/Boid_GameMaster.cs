using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid_GameMaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        InvokeRepeating("Spawn", 0.5f, 0.5f);
        
    }

    public int BoidCount;
    public GameObject boid;
    int spawned = 0; 
    void Spawn(){

        spawned++; 
        Instantiate(boid, transform.position, Quaternion.identity);
        
        if(BoidCount <= spawned){
            Destroy(gameObject); 
        }
    }
}
