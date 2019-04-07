using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public int starForce = 0, roachSwarm = 0;
    public static GameObject GM;
    bool canWin = false;
    public Image blackBackGround;
    public Text endofGameText;
    void Start()
    {
        GM = this.gameObject;
        Invoke("GameOn", 60f);
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
    string endofGameDisplay; 
    
    void VictoryCheck(){
        if(timer > 60 * 2.5){

            if(starForce > roachSwarm){
                VictoryDisplay("Star Force", "Imperal Swarm");
            } else{
                VictoryDisplay("Imperal Swarm", "Star Force");
            }

        }
        timer += Time.deltaTime;
        if (starForce >= roachSwarm * 2) {
            VictoryDisplay("Star Force", "Imperal Swarm");
        }

        if (roachSwarm >= starForce * 2) {
            VictoryDisplay( "Imperal Swarm", "Star Force");
        }

    } 
    void VictoryDisplay(string winner, string loser){
       blackBackGround.enabled = true; 
       endofGameDisplay = " Faced with overwhelming opposition "+ loser + " had no choice but to retreat. Leaving the "+winner+" to explore deep space once more unopposed.";
        endofGameText.text = endofGameDisplay; 
    }

    void GameOn(){
        canWin = true; 
    }
}
