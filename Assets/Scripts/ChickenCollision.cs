using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChickenCollision : MonoBehaviour
{

    public GameObject innerChicken;
    public GameObject chicken;
    public GameObject squishedChicken;
    public AudioSource soundsToPlay;
    public AudioSource waterSounds;



    private void Start()
    {
        
        chicken = this.gameObject;
        squishedChicken.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {

            soundsToPlay.Play();
            squishedChicken.SetActive(true);
            innerChicken.SetActive(false);
            Invoke("BackToMain",.5f);

        }

        if(collision.gameObject.tag == "Log")
        {


            chicken.transform.parent = collision.transform;


        }

        if(collision.gameObject.tag == "Water")
        {
            waterSounds.Play();
            innerChicken.SetActive(false);
            Invoke("BackToMain", .8f);
        }

        if(collision.gameObject.tag == "Egg")
        {

            innerChicken.SetActive(false);
            squishedChicken.SetActive(true);
            soundsToPlay.Play();
            Invoke("BackToMain", .4f);

        }

       

    }

   void BackToMain()
   {
        SceneManager.LoadScene("MainMenu");
   }


}
