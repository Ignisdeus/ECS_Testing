using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public int starForce = 0, roachSwarm = 0;
    public static GameObject GM; 
    void Start()
    {
        GM = this.gameObject; 
    }

    public Text[] textinfo;
    void Update()
    {
        textinfo[0].text = "Starforce = " + starForce.ToString().ToUpper();
        textinfo[1].text = "RoachSwarm = " + roachSwarm.ToString().ToUpper();

    }
}
