using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
   

    public void OnClickPlay()
    {

        SceneManager.LoadScene("NCG Test");
        Debug.Log("You clicked the Play Button");

    }


    public void OnclickQuit()
    {

        Application.Quit();
        Debug.Log("You have clicked the quit button");

    }

    public void OnclickInstructions()
    {

        //SceneManager.LoadScene("");
        Debug.Log("You have clicked the InstructionsButton");

    }


    public void OnclCickCredits()
    {

        //SceneManager.LoadScene("");
        Debug.Log("You ahve clicked the creditsButton");

    }


   public void OnclickMenu()
   {

     //this will pull up the menu during gameplay to acess quit button, back to main menu button, or other buttons needed

   }



}
