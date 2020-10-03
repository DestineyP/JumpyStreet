using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceSoundTrigger : MonoBehaviour
{


    public GameObject playerobj;
    public GameObject thisObject;
    public AudioSource soundsToPlay;
    public float distance;
    public bool isFinding;

    void Start()
    {
        
        isFinding = true;
        StartCoroutine(FindplayerLocation());
    }
    IEnumerator FindplayerLocation()
    {

        while (isFinding) 
        {

            distance = Vector3.Distance(thisObject.transform.position, playerobj.transform.position);   
            
            if (distance < 5)
            {

                Debug.Log("PlayingSound");
                soundsToPlay.Play();
               //this will be where I will Play the audioClip. The audio clip will be global and public so I can change out the clip 
                //per item that needs to have this script attacthed to it. I will use another courountine to check if it is far away 
                //from player to stop the audio. 

                isFinding = false;  

            }
            yield return null;


        }
        yield return new WaitForSeconds(1);
    }


}
