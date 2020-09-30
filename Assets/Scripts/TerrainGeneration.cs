using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{


    /// <summary>
    /// William CHANGE CODE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    /// </summary>
    public GameObject Grass, Water, Road; //Our Different Terrain Types

    int firstRand, secondRand, disPlayer;

    Vector3 intPos = new Vector3(0,0,0);

    void Update()
    {
        if (Input.GetButton ("Up"))
        {
            firstRand = Random.Range(1, 4);
            if (firstRand == 1) // Generation of Grass
            {
                secondRand = Random.Range(1, 8); //Note to self - Ajust this later. This affects how many common this tpye of tile is. - William
                for (int i= 0; i < secondRand; i++)
                {
                    intPos = new Vector3(0, -.1f, disPlayer);
                    disPlayer += 1;
                    GameObject GrassInt = Instantiate(Grass) as GameObject;
                    GrassInt.transform.position = intPos;
                }
            }

            if (firstRand == 2) //Generation of Road
            {
                secondRand = Random.Range(1, 8); //Note to self - Ajust this later. This affects how many common this tpye of tile is. - William
                for (int i = 0; i < secondRand; i++)
                {
                    intPos = new Vector3(0, -.2f, disPlayer);
                    disPlayer += 1;
                    GameObject RoadInt = Instantiate(Road) as GameObject;
                    RoadInt.transform.position = intPos;
                }
            }

            if (firstRand == 3) //Generation of the water
            {
                secondRand = Random.Range(1, 8); //Note to self - Ajust this later. This affects how many common this tpye of tile is. - William
                for (int i = 0; i < secondRand; i++)
                {
                    intPos = new Vector3(0, 0, disPlayer);
                    disPlayer += 1;
                    GameObject WaterInt = Instantiate(Water) as GameObject;
                    WaterInt.transform.position = intPos;
                }
            }
        }
    }
}
