using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceSoundTrigger : MonoBehaviour
{


    public GameObject playerobj;
    public AudioSource soundsToPlay;
    public float distance;
    public bool isFinding;
    public bool soundOn;
    public bool playerHasLeft;

    void Start()
    {
        soundOn = false;
        isFinding = true;
        StartCoroutine(FindIfClose());
       
    }
    IEnumerator FindIfClose()
    {

        while (isFinding) 
        {

            distance = Vector3.Distance(gameObject.transform.position, playerobj.transform.position);   
            
            if (this.gameObject.name == "road" && distance < 5)
            {

               // Debug.Log("PlayingSound");
                soundsToPlay.Play();
                isFinding = false;
                soundOn = true;
                StartCoroutine(FindIfFar());
            }

            if (this.gameObject.name == "waterSound" && distance < 6)
            {
                Debug.Log("Water");
                // Debug.Log("PlayingSound");
                soundsToPlay.Play();
                isFinding = false;
                soundOn = true;
                StartCoroutine(FindIfFar());
            }

            yield return null;


        }

   
        yield return new WaitForSeconds(3);
    }


    IEnumerator FindIfFar()
    {

        while (soundOn)
        {

            distance = Vector3.Distance(gameObject.transform.position, playerobj.transform.position);

            if (this.gameObject.name == "waterSound" && distance > 8)
            {

               
                soundsToPlay.Stop();
                soundOn = false;

            }
            if (this.gameObject.name == "road" && distance > 5)
            {

               
                soundsToPlay.Stop();
                soundOn = false;

            }

            yield return null;


        }

    
        yield return new WaitForSeconds(3);
    }





}
