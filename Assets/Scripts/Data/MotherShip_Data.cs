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
    public GameObject enemy; 

    int count = 0 ;


    Vector3[] grid = new Vector3[300] ;
    private void Awake()
    {
        int horzMount = 20;
        int vertMount = 275 / horzMount;
        int zPos;

        if (tag == "MotherShipB") {
            zPos = 20;
        } else {
            zPos = -20;
        }
        for (int y = 0; y < vertMount; y++) {

            for (int x = 0; x < horzMount; x++) {

                grid[y * horzMount + x] = new Vector3(x * formationSeparation, y * formationSeparation, zPos);

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
            x.GetComponent<Boid_Data>().target = grid[i]; 
            x.GetComponent<Boid_Data>().enemyMotherShip = enemy;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
