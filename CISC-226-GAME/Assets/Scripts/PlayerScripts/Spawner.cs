using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Chicken_Prefab;
    [SerializeField] private GameObject Cow_Prefab;
    [SerializeField] private GameObject Hog_Prefab;
    [SerializeField] private GameObject Pig_Prefab;

    [SerializeField] private Vector2[] spawnPositions;

    private void Start()
    {
        SpawnPrefabs();
    }

    private void SpawnPrefabs()
    {
        foreach(Vector2 spawnPosition in spawnPositions)
        {
            Instantiate(Chicken_Prefab, spawnPosition, Quaternion.identity);
            Instantiate(Cow_Prefab, spawnPosition, Quaternion.identity);
            Instantiate(Hog_Prefab, spawnPosition, Quaternion.identity);
            Instantiate(Pig_Prefab, spawnPosition, Quaternion.identity);
        }
    }


}
