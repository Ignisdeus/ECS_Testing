using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Data : MonoBehaviour
{
    [HideInInspector]
    public Ray ray;
    [HideInInspector]
    public RaycastHit hit;
    public float rayLenght = 10f;
    public Transform rayCastPoint;
    public GameObject roachExpl, BirdExpl; 
    
    public bool rayCastworking = false;
    public string enemyTag;
    public AudioSource audioS;
    public AudioClip[] audioSounds; 
    
    public float timeBetweenShots;
    bool canShoot;


    private void Start()
    {
                    if (gameObject.tag == "BirdShip") {
                        enemyTag = "Drone";
                    } else {
                        enemyTag = "BirdShip";
                    }
        audioS = GetComponent<AudioSource>(); 
    }
    public IEnumerator RayCheck()
    {

        yield return new WaitForSeconds(Random.Range(0, 0.5f));


        Vector3 fwd = rayCastPoint.forward;
        //Debug.DrawRay(rayCastPoint.position, rayCastPoint.TransformDirection(Vector3.forward) * rayLenght, Color.red);
        //Debug.DrawRay(blasters[0].position, blasters[0].TransformDirection(Vector3.forward) * rayLenght, Color.red);
        if (Physics.SphereCast(rayCastPoint.position, 2f, rayCastPoint.TransformDirection(Vector3.forward), out hit, rayLenght)) {
            //Debug.DrawRay(x.rayCastPoint.position, x.rayCastPoint.TransformDirection(Vector3.forward) * x.hit.distance, Color.yellow);

            if(hit.collider.tag == enemyTag && !canShoot){
                canShoot = true; 
                //Debug.Log("Engage " + enemyTag);
                
                GetComponent<Presue>().target = hit.collider.gameObject.GetComponent<Boid_Data>();
                GetComponent<Presue>().weight = 1;
                GetComponent<CustomWonder>().weight = 0; 
                GetComponent<Boid_Data>().action = Boid_Data.Behaviour.hunt;
               //GetComponent<Presue>().target = hit.collider.gameObject.GetComponent<Boid_Data>(); 

            }
            if(hit.collider.tag == enemyTag){
                //canShoot = false; 
                GetComponent<Boid_Data>().action = Boid_Data.Behaviour.engage;
                StartCoroutine(FireAtWill());

            } 
        }
        StartCoroutine(RayCheck());
    }

    Ray[] shoot = new Ray[2];
    RaycastHit[] shot = new RaycastHit[2];
    public Transform[] blasters;
    IEnumerator FireAtWill(){

        yield return new WaitForSeconds(timeBetweenShots);

            //Debug.DrawRay(blasters[0].position, blasters[0].TransformDirection(Vector3.forward) * rayLenght, Color.red);
            if(Physics.SphereCast(blasters[0].position,2f, blasters[0].TransformDirection(Vector3.forward), out shot[0], rayLenght)){
            GameObject x = shot[0].collider.gameObject;
            if (shot[0].collider.tag == enemyTag && GetComponent<Presue>().target != null ) {
                StartCoroutine(LineRender(shot[0].collider.transform));
                    x.GetComponent<Health>().health -= AmountToRemove();

                    if (x.GetComponent<Health>().health <= 0) {
                        audioS.PlayOneShot(audioSounds[0], 1f);
                        canShoot = false; 
                        GetComponent<Boid_Data>().action = Boid_Data.Behaviour.explore;
                        if (tag == "BirdShip") {
                            Instantiate(roachExpl, shot[0].transform.position, shot[0].collider.gameObject.transform.rotation);
                            GameMaster.GM.GetComponent<GameMaster>().roachSwarm--;
                        }else{
                        Instantiate(BirdExpl, shot[0].transform.position, shot[0].collider.gameObject.transform.rotation);
                        GameMaster.GM.GetComponent<GameMaster>().starForce--;
                        }
                        
                        Destroy(x.gameObject);
                        //Debug.Log("killed him");
                    }
                }
            }
    }

    public LineRenderer[] lines;
    IEnumerator LineRender(Transform x){
        //Debug.Log("Fire");
        // create point to fire lazer to 

        Vector3 fwd = blasters[0].transform.forward;
        fwd *= Vector3.Distance(transform.position, x.position); 
        for(int i =0; i < lines.Length; i ++){
            lines[i].enabled = true;
            audioS.PlayOneShot(audioSounds[1], 1f); 
            lines[i].SetPosition(0, blasters[i].transform.position);
            lines[i].SetPosition(1, fwd);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        for (int i = 0; i < lines.Length; i++) {
            lines[i].enabled = false;
        }



    }
    int AmountToRemove(){
        int x=0;
        int damage = Random.Range(20,70);
        float critRate = 1.7f; 
        if (Random.Range(0f,1f) > 0.7f){
            x = Mathf.RoundToInt(damage * critRate); 

        }else{
            x = damage;
        }


        return x;
    }
}
