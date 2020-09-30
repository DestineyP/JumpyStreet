using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCollision : MonoBehaviour
{

    public GameObject chickenDeath;
    public GameObject chicken;
    public GameObject deathPanel;



    private void Start()
    {
        chickenDeath.SetActive(false);
        chicken = this.gameObject;
        deathPanel.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            deathPanel.SetActive(true);
            chickenDeath.SetActive(true);
            chicken.SetActive(false);

        }
    }



}
