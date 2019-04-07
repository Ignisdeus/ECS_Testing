using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class MenuMaster : MonoBehaviour
{

    public Slider star, roach;
    public Text starT, roachT;

    bool inMenu = true; 
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject); 
    }

    // Update is called once per frame
    void Update()
    {
        if(inMenu){
            MenuCode();
        }
         
    }

    void MenuCode(){

        starT.text = star.value.ToString();
        roachT.text = roach.value.ToString();

        if(star.value == 0  && roach.value ==0){
            inMenu = false;
            Invoke("PassingInfo", 4f);
            SceneManager.LoadScene(levelToLoad);

        } 

    }
    public string levelToLoad;
    int starSpawnAmount=0 , roachSpawnAmount=0; 
    public void StartGame(){
        starSpawnAmount = (int)star.value;
        roachSpawnAmount = (int)roach.value;
        roach.interactable = false;
        star.interactable = false; 
        roach.minValue = 0;
        star.minValue = 0; 
        //StartGame();
        InvokeRepeating("VisualsEffect", 0.025f, 0.025f);


    }

    void VisualsEffect(){
        roach.value--;
        star.value--;
    } 
    IEnumerator LoadingLevelVisuals(){

        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(levelToLoad);

    }

    void PassingInfo(){

        GameObject.FindGameObjectWithTag("MotherShipB").GetComponent<MotherShip_Data>().babyShips = starSpawnAmount;
        GameObject.FindGameObjectWithTag("MotherShipR").GetComponent<MotherShip_Data>().babyShips = roachSpawnAmount;
        Destroy(gameObject); 

    }
}
