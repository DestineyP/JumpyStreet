using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public GameObject[] trees = new GameObject[8];
    public GameObject[] spawners = new GameObject[15];

    // Start is called before the first frame update
    void Start()
    {
        SpawnTrees();
    }

    private void SpawnTrees()
    {
        for(int i = 0; i < 15; i++)
        {
            int spawnChance = Random.Range(1, 4); //creates a chance to spawn the tree
            if(spawnChance < 3)
            {
                int randomTree = Random.Range(0, 8);//random tree from available meshes
                Instantiate(trees[randomTree], spawners[i].transform.position, trees[randomTree].transform.rotation);
            }
        }
    }
}
