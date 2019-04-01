using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip_Data : MonoBehaviour
{
    public bool combat = false;
    public Path_Data combatPath;
    public Transform[] spawners;
    public GameObject miniShips;
    public int babyShips = 100;

    int count = 0 ; 
    public IEnumerator Spawn(){

        if(babyShips > count ){


            count++; 
            Instantiate(miniShips, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            Spawn(); 
        }else{
            yield return new WaitForSeconds(0.1f);
            
        }

    }

}
