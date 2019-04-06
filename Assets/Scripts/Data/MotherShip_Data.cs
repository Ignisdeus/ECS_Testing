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
    public bool canSpawn = true; 

    int count = 0 ; 
    public IEnumerator Spawn(){
        for(int i =0; i < babyShips; i ++){
            Instantiate(miniShips, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
