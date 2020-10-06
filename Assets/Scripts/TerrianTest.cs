using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrianTest : MonoBehaviour
{

    public List<GameObject> cloneList = new List<GameObject>();

    public GameObject[] terrain;
    public GameObject lastSpawned;

    float currentOffset = 8f;
    bool gamePlays = true;

    // Use this for initialization
    void Start()
    {
        gamePlays = true;
        StartCoroutine(TerrainSpawner()); 
       
    }


    private IEnumerator TerrainSpawner()
    {

        while (gamePlays)
        {
            int randomTerrain = Random.Range(0, 3);

            Vector3 localOffset = new Vector3(currentOffset, 0, 0);

            Vector3 spawnPosition = lastSpawned.transform.position + localOffset;

            GameObject clone = Instantiate(terrain[randomTerrain], spawnPosition, transform.rotation * Quaternion.Euler(90, 0, 0));

            lastSpawned = clone;

            cloneList.Add(lastSpawned);

            int listLength = cloneList.Count;
            if(listLength > 20)
            {

                cloneList[0].SetActive(false);
                Destroy(cloneList[0]);
                cloneList.RemoveAt(0);

            }

             // Debug.Log(lastSpawned.name);


            yield return new WaitForSeconds(4);

        }

        yield return new WaitForSeconds(4);

    }



}
