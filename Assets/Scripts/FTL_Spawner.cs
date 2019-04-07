using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTL_Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FTL", 0f, 0.25f);
    }
    public Transform muzzle;
    public GameObject FTlEffect; 
    void FTL(){

        Instantiate(FTlEffect, muzzle.transform.position, Quaternion.identity);


    }
}
