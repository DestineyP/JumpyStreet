using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChickenCollision : MonoBehaviour
{

   
    public GameObject chicken;
    public GameObject deathPanel;



    private void Start()
    {
        
        chicken = this.gameObject;
        deathPanel.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
           // deathPanel.SetActive(true);

           // chicken.SetActive(false);
           // Debug.Log("IsHit");

            SceneManager.LoadScene("MainMenu");

        }

        if(collision.gameObject.tag == "Log")
        {


            chicken.transform.parent = collision.transform;


        }


    }

   


}
