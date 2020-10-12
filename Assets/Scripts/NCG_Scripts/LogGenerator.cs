using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogGenerator : MonoBehaviour
{
    public GameObject logPrefab;
    public GameObject[] lanes = new GameObject[3];

    void Start()
    {
        StartCoroutine(LaneSpawning1());
        StartCoroutine(LaneSpawning2());
        StartCoroutine(LaneSpawning3());
        StartCoroutine(LaneSpawning4());
        StartCoroutine(LaneSpawning5());
        StartCoroutine(LaneSpawning6());
        StartCoroutine(LaneSpawning7());
        StartCoroutine(LaneSpawning8());
    }

    #region IEnumerators
    //Spawning rates are hard-coded for now.  These can be easily randomized, but for testing purposes it was easier to just use hard-coded
    //times.  Each of these 

    private IEnumerator LaneSpawning1()
    {
        int randomSeconds = Random.Range(2, 5);  //To add randomness to the spawns

        yield return new WaitForSeconds(randomSeconds);  // wait for seconds was originally 3 seconds
        Instantiate(logPrefab, lanes[0].transform.position, lanes[0].transform.rotation);

        StartCoroutine(LaneSpawning1());
    }

    private IEnumerator LaneSpawning2()
    {
        int randomSeconds = Random.Range(2, 5); //To add randomness to the spawns
        yield return new WaitForSeconds(randomSeconds); // wait for seconds was originally 3 seconds
        Instantiate(logPrefab, lanes[1].transform.position, lanes[1].transform.rotation);

        StartCoroutine(LaneSpawning2());
    }

    private IEnumerator LaneSpawning3()
    {
        int randomSeconds = Random.Range(2, 5); //To add randomness to the spawns
        yield return new WaitForSeconds(randomSeconds); // wait for seconds was originally 3 seconds
        Instantiate(logPrefab, lanes[2].transform.position, lanes[2].transform.rotation);

        StartCoroutine(LaneSpawning3());
    }

    private IEnumerator LaneSpawning4()
    {
        int randomSeconds = Random.Range(2, 5); //To add randomness to the spawns
        yield return new WaitForSeconds(randomSeconds); // wait for seconds was originally 3 seconds
        Instantiate(logPrefab, lanes[3].transform.position, lanes[3].transform.rotation);

        StartCoroutine(LaneSpawning4());
    }

    private IEnumerator LaneSpawning5()
    {
        int randomSeconds = Random.Range(2, 5);  //To add randomness to the spawns

        yield return new WaitForSeconds(randomSeconds);  // wait for seconds was originally 3 seconds
        Instantiate(logPrefab, lanes[4].transform.position, lanes[4].transform.rotation);

        StartCoroutine(LaneSpawning5());
    }

    private IEnumerator LaneSpawning6()
    {
        int randomSeconds = Random.Range(2, 5); //To add randomness to the spawns
        yield return new WaitForSeconds(randomSeconds); // wait for seconds was originally 3 seconds
        Instantiate(logPrefab, lanes[5].transform.position, lanes[5].transform.rotation);

        StartCoroutine(LaneSpawning6());
    }

    private IEnumerator LaneSpawning7()
    {
        int randomSeconds = Random.Range(2, 5); //To add randomness to the spawns
        yield return new WaitForSeconds(randomSeconds); // wait for seconds was originally 3 seconds
        Instantiate(logPrefab, lanes[6].transform.position, lanes[6].transform.rotation);

        StartCoroutine(LaneSpawning7());
    }

    private IEnumerator LaneSpawning8()
    {
        int randomSeconds = Random.Range(2, 5); //To add randomness to the spawns
        yield return new WaitForSeconds(randomSeconds); // wait for seconds was originally 3 seconds
        Instantiate(logPrefab, lanes[7].transform.position, lanes[7].transform.rotation);

        StartCoroutine(LaneSpawning8());
    }
    #endregion
}
