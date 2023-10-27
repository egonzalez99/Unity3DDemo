using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject cubes; 
    public int numberOfCubes = 100;
    public float spawnRadius = 10f;


    private void Start()
    {
        SpawnCubes();

    }

    private void SpawnCubes()
    {

            for (int i = 0; i < numberOfCubes; i++)
        {
            // random position for sphere to spawn within
            Vector3 spawnLocation = new Vector3(435, 7, 323);

            Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;

            Vector3 spawnPosition = spawnLocation + randomPosition;

            Instantiate(cubes, spawnPosition, Quaternion.identity);
        }
    }
}
