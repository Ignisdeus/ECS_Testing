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
    

    public void Spawn(Vector3 x){
        Instantiate(miniShips, x, Quaternion.identity);

    }

}
