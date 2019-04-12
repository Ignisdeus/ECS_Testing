using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Entities; 

public class GameMaster : MonoBehaviour
{
    public int starForce = 0, roachSwarm = 0;
    public static GameObject GM;
    bool canWin = false;
    public GameObject restartButton;
    public Text endofGameText;
    public Image fadeImage; 
    void Start()
    {
        GM = this.gameObject;
        restartButton.SetActive(false); 
        Invoke("GameOn", 60f);
        StartCoroutine(FadeEffect());
    }

    public Text[] textinfo;
    float timer; 
    void Update()
    {
        textinfo[0].text = starForce.ToString().ToUpper();
        textinfo[1].text = roachSwarm.ToString().ToUpper();
        
        if(canWin){

            VictoryCheck();
        }


    }
    string endofGameDisplay;// not needed anymore remove when ready  
    public GameObject birdExpl, roachExpl;
    public float minNumber = 10; 
    void VictoryCheck(){
        if (starForce < minNumber) {
            GameObject[] x = GameObject.FindGameObjectsWithTag("BirdShip");

            foreach(GameObject g in x){

                g.GetComponent<Health>().health = 0;
                Instantiate(birdExpl, g.transform.position, Quaternion.identity);
                Destroy(g.gameObject); 
            }
            starForce = 0;
            restartButton.SetActive(true);
        }

        if (roachSwarm < minNumber) {
            GameObject[] x = GameObject.FindGameObjectsWithTag("Drone");

            foreach (GameObject g in x) {

                g.GetComponent<Health>().health = 0;
                Instantiate(roachExpl, g.transform.position, Quaternion.identity);
                Destroy(g.gameObject);
            }
            roachSwarm = 0;
            restartButton.SetActive(true);
        }


    } 
    void VictoryDisplay(string winner, string loser){
       //blackBackGround.enabled = true; 
       endofGameDisplay = " Faced with overwhelming opposition "+ loser + " had no choice but to retreat. Leaving the "+winner+" to explore deep space once more unopposed.";
       endofGameText.text = endofGameDisplay; 
    }

    void GameOn(){
        canWin = true; 
    }


    public List<GameObject> allShips = new List<GameObject>();
    public float timeBeforeBattleStarts = 20f; 
    public IEnumerator BeginFight(){
        yield return new WaitForSeconds(timeBeforeBattleStarts); 
        for( int x =0; x < allShips.Count; x ++){ 
            allShips[x].GetComponent<Boid_Data>().action =  Boid_Data.Behaviour.explore; 
            allShips[x].GetComponent<Boid_Data>().target =  allShips[x].GetComponent<CustomWonder>().target;
            allShips[x].GetComponent<CustomWonder>().weight = 1f; 
            allShips[x].GetComponent<Drone_Data>().enabled = true;
            allShips[x].GetComponent<ArriveBehaviour>().weight =0f;
            allShips[x].GetComponent<SeekBehaviour>().weight =0f;
            StartCoroutine(StartTheStorm());

        } 
    } 
    public void BeginFightCommand(){
        StartCoroutine(BeginFight());
    }

    IEnumerator StartTheStorm()
    {
        for(int i = 125;  i > 5; i -=4){

            CustomWonder.radus = i;
            if(i <=10){
                i = 75;
            }
            yield return new WaitForSeconds(1f);


        } 
    }
    public string levelToLoad;
    public void LoadLevel(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelToLoad);
    }

    IEnumerator FadeEffect(){
        fadeImage.color = new Color(0, 0, 0, 1);
        float fadeAmount = 1;
        for ( int i = 100; i > 0; i --){
            fadeAmount -= 0.01f;
            fadeImage.color = new Color(0,0,0,fadeAmount);
            yield return new WaitForSeconds(0.05f); 

        } 

    }

    public void CalledFade(){
        StartCoroutine(FadeEffect());
    }
}
