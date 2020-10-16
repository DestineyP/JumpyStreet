using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrianTest : MonoBehaviour
{

    public List<GameObject> cloneList = new List<GameObject>();

    public GameObject[] terrain;
    public GameObject lastSpawned;
    GameObject clone;

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

            if (lastSpawned.name == "Water(Clone)")
            {
                spawnPosition.y = spawnPosition.y + .20f;
                clone = Instantiate(terrain[randomTerrain], spawnPosition, transform.rotation * Quaternion.Euler(90, 0, 0));
            }
            else
            {

                clone = Instantiate(terrain[randomTerrain], spawnPosition, transform.rotation * Quaternion.Euler(90, 0, 0));

            }

            if(clone.name == "Water(Clone)")
            {
                clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y - .20f, clone.transform.position.z); 
            }

            lastSpawned = clone;
          //  Debug.Log(lastSpawned.name);

            cloneList.Add(lastSpawned);

            int listLength = cloneList.Count;
            if(listLength > 50)
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
