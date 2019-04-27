using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalExplosion : MonoBehaviour
{


    private void Start()
    {
        Invoke("Expl", 5f);
    }
    public GameObject motherShip;
    public float radius = 5f;
    public GameObject expl; 
    void Expl(){

        for( int i = 0; i < 10; i ++){
            Vector3 pos;
            pos = Random.insideUnitSphere * (radius) + motherShip.transform.position;
            Instantiate(expl, pos, Quaternion.identity);
        }
        motherShip.GetComponentInChildren<Renderer>().enabled = false;
        TrailRenderer[] trails =  motherShip.GetComponentsInChildren<TrailRenderer>(); 

        foreach(TrailRenderer t in trails){

            t.enabled = false; 

        }


    } 
}
