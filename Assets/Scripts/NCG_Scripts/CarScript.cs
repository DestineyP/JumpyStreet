using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    private void Awake() //call for the destruction of the car in time.  This will be replaced with a kill box after a while.
    {
        StartCoroutine(DestroySelf());
    }

    private void Update() //Movement for the car.
    {
        transform.Translate(new Vector3(0, -Time.deltaTime * 3, 0));
    }

    private void OnCollisionEnter(Collision collision) //Collision setup to interact with the player
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit " + this.name);
        }
    }

    IEnumerator DestroySelf()  //This was the "Plan B" for the destruction of the cars.
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Destroy" + this.gameObject.name);
        Destroy(gameObject);
    }


}
