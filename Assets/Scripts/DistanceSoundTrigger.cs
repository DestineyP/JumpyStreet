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
        StartCoroutine(FindIfFar());
    }
    IEnumerator FindIfClose()
    {

        while (isFinding) 
        {

            distance = Vector3.Distance(gameObject.transform.position, playerobj.transform.position);   
            
            if (distance < 5)
            {

               // Debug.Log("PlayingSound");
                soundsToPlay.Play();
                isFinding = false;
                soundOn = true;

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

            if (this.gameObject.name == "Water(Clone)" && distance > 2)
            {

               // Debug.Log("Should Stop water");
                soundsToPlay.Stop();
                soundOn = false;

            }
            if (this.gameObject.name == "road" && distance > 5)
            {

               // Debug.Log("PlayingSound");
                soundsToPlay.Stop();
                soundOn = false;

            }

            yield return null;


        }

    
        yield return new WaitForSeconds(3);
    }





}
