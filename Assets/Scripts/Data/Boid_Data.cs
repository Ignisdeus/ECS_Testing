using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid_Data : MonoBehaviour
{
    public string enemy;
    public enum Behaviour{
        explore,
        hunt, 
        engage,
        run,
        formation,
        InFormation

    }

    public Behaviour action; 
    [HideInInspector]
    public float rayCastTimer, currentTime; 
    public Vector3 force = Vector3.zero, acceleration = Vector3.zero,  velocity = Vector3.zero, target, formationPosistion;
    public float mass = 1;

    [Range(0.0f, 10.0f)]
    public float damping = 0.01f;

    [Range(0.0f, 1.0f)]
    public float banking = 0.1f;
    public float maxSpeed = 5.0f;
    public float maxForce = 10.0f; 
    public List<SteeringBehaviour> movement = new List<SteeringBehaviour>();
    
    public GameObject enemyMotherShip; 
    public bool isMotherShip; 
    public Vector3 LookAtPos;
    private void Start()
    {
        
        LookAtPos = new Vector3(target.x,target.y,0);
        //action = Behaviour.explore; 
        rayCastTimer = Random.Range(0,5f);
        SteeringBehaviour[] behaviours = GetComponents<SteeringBehaviour>();

        foreach (SteeringBehaviour x in behaviours){
            if (x.isActiveAndEnabled){
                movement.Add(x);
            }
        
        }
        if(!isMotherShip){
            GameMaster.GM.GetComponent<GameMaster>().allShips.Add(gameObject);
        }

    }



    
}
