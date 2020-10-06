using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
   

    public void OnClickPlay()
    {

        SceneManager.LoadScene("PlayScene");
        Debug.Log("You clicked the Play Button");

    }


    public void OnclickQuit()
    {

        Application.Quit();
        Debug.Log("You have clicked the quit button");

    }

    public void OnclickInstructions()
    {

        SceneManager.LoadScene("InstructionsScene");
        Debug.Log("You have clicked the InstructionsButton");

    }


    public void OnclCickCredits()
    {

        SceneManager.LoadScene("CreditsScene");
        Debug.Log("You ahve clicked the creditsButton");

    }


   public void OnclickMenu()
   {

        SceneManager.LoadScene("MainMenu");

   }



}
