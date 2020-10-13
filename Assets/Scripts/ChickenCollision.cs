using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            deathPanel.SetActive(true);
            
            chicken.SetActive(false);

        }

        if(collision.gameObject.tag == "Log")
        {


            chicken.transform.parent = collision.transform;


        }


    }

    


}
