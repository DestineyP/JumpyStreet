using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour
{
    public GameObject[] carPrefabs = new GameObject[4];
    public GameObject[] lanes = new GameObject[3];

    void Start()
    {
        StartCoroutine(LaneSpawning1());
        StartCoroutine(LaneSpawning2());
        //StartCoroutine(LaneSpawning3());    Commented out to test a 2 lane Road
    }

    #region IEnumerators
    //Spawning rates are hard-coded for now.  These can be easily randomized, but for testing purposes it was easier to just use hard-coded
    //times.  Each of these 

    private IEnumerator LaneSpawning1()
    {
        int car = Random.Range(0, 4);
        int randomSeconds = Random.Range(2, 5);  //To add randomness to the spawns

        yield return new WaitForSeconds(randomSeconds);  // wait for seconds was originally 3 seconds
        Instantiate(carPrefabs[car], lanes[0].transform.position, lanes[0].transform.rotation);

        StartCoroutine(LaneSpawning1());
    }

    private IEnumerator LaneSpawning2()
    {
        int car = Random.Range(0, 4);
        int randomSeconds = Random.Range(2, 5); //To add randomness to the spawns
        yield return new WaitForSeconds(randomSeconds); // wait for seconds was originally 3 seconds
        Instantiate(carPrefabs[car], lanes[1].transform.position, lanes[0].transform.rotation);

        StartCoroutine(LaneSpawning2());
    }

    private IEnumerator LaneSpawning3()
    {
        int car = Random.Range(0, 4);
        yield return new WaitForSeconds(1);
        Instantiate(carPrefabs[car], lanes[2].transform.position, lanes[0].transform.rotation);

        StartCoroutine(LaneSpawning3());
    }
    #endregion
}
