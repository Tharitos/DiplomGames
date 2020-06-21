using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject buttonsStart_Game;
    public GameObject buttonsContinue;
    public GameObject buttonsSave;
    public GameObject buttonsLoad;
    public GameObject buttonsExit;
    public GameObject LoadingScreen;
    // Start is called before the first frame update
    public void Start_Game()
    {
        //LoadingScreen.SetActive(true);
        Global_Script.Game_On = true;
        Application.LoadLevel(1);
    }

    public void Continue()
    {
        
    }

    public void Load()
    {
        
    }
    /*public void ShowExitButtions(){
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(true);
    }*/
    public void Exit_Game()
    {
        Application.Quit();
    }

    void  FixedUpdate()
    {
        if (Global_Script.Game_On){
            LoadingScreen.SetActive(false);
            buttonsContinue.SetActive(true);
            buttonsSave.SetActive(true);
            buttonsStart_Game.SetActive(false);
        }
        else{
            LoadingScreen.SetActive(false);
            buttonsContinue.SetActive(false);
            buttonsStart_Game.SetActive(false);
            buttonsStart_Game.SetActive(true);
        }
    }

}
