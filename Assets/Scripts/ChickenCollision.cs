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
            Invoke("backToMain",.5f);

        }

        if(collision.gameObject.tag == "Log")
        {


            chicken.transform.parent = collision.transform;


        }

        if(collision.gameObject.tag == "Water")
        {
            waterSounds.Play();
            innerChicken.SetActive(false);
            Invoke("backToMain", .8f);
        }


    }

   void backToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
