using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{

    public AudioSource buttonClick;
    public void OnClickPlay()
    {
        buttonClick.Play();
        SceneManager.LoadScene("PlayScene");
        Debug.Log("You clicked the Play Button");

    }


    public void OnclickQuit()
    {
        buttonClick.Play();
        Application.Quit();
        Debug.Log("You have clicked the quit button");

    }

    public void OnclickInstructions()
    {
        buttonClick.Play();
        // SceneManager.LoadScene("InstructionsScene");
        Invoke("ChangetoInstructions", .2f);
        Debug.Log("You have clicked the InstructionsButton");

    }


    public void OnclCickCredits()
    {
        buttonClick.Play();
       // SceneManager.LoadScene("CreditsScene");
        Debug.Log("You ahve clicked the creditsButton");
        Invoke("ChangetoCredits", .2f);
    }


    public void OnclickMenu()
    {
        buttonClick.Play();
        // SceneManager.LoadScene("MainMenu");
        Invoke("ChangetoMenu",.2f);

    }


    void ChangetoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void ChangetoCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    void ChangetoInstructions()
    {
        SceneManager.LoadScene("CreditsScene");
    }

}
