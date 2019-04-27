using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class MotherShip_Data : MonoBehaviour
{
    public bool combat = false;
    public Path_Data combatPath;
    public Transform[] spawners;
    public GameObject miniShips;
    public int babyShips = 100;
    public bool canSpawn = true; 
    public GameObject enemy;
    public float distFromCenter;
    int count = 0 ;


    Vector3[] grid = new Vector3[320] ;
    private void Start()
    {
        int horzMount = 20;
        int vertMount = 320 / horzMount;
        int zPos;

        if (tag == "MotherShipB") {
            zPos = 20;
        } else {
            zPos = -20;
        }
        for (int y = 0; y < vertMount; y++) {

            for (int x = 0; x < horzMount; x++) {
                if( y % 2 ==0){
                    grid[(y * horzMount) + x] = new Vector3((x * formationSeparation) - formationSeparation/2, y * formationSeparation, zPos);
                } else{
                    grid[(y * horzMount) + x] = new Vector3(x * formationSeparation, y * formationSeparation, zPos);
                } 
                

            }
        }



    }
    public float formationSeparation = 5f; 
    public IEnumerator Spawn(){

        for(int i =0; i < babyShips; i ++){        
            if(tag == "MotherShipB"){
                GameMaster.GM.GetComponent<GameMaster>().starForce++; 
            }else{
                GameMaster.GM.GetComponent<GameMaster>().roachSwarm++; 
            }
            
            GameObject x= Instantiate(miniShips, transform.position, Quaternion.identity);
            
            x.GetComponent<Boid_Data>().formationPosistion = grid[i]; 
            x.GetComponent<Boid_Data>().enemyMotherShip = enemy;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
