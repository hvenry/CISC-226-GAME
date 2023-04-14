using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Chicken_Prefab;
    [SerializeField] private GameObject Cow_Prefab;
    [SerializeField] private GameObject Hog_Prefab;
    [SerializeField] private GameObject Pig_Prefab;
    [SerializeField] private int numberofPrefabs;


    [SerializeField] private Vector2 corner1;
    [SerializeField] private Vector2 corner2;

    private void Start()
    {
        SpawnPrefabs();
    }

    private void SpawnPrefabs()
    {
        for (int i = 0; i < numberofPrefabs; i++)
        {
            Vector2 spawnPosition = GetRandomPosition();
            Instantiate(Chicken_Prefab, spawnPosition, Quaternion.identity);
            //Instantiate(Cow_Prefab, spawnPosition, Quaternion.identity);
            //Instantiate(Hog_Prefab, spawnPosition, Quaternion.identity);
            //Instantiate(Pig_Prefab, spawnPosition, Quaternion.identity);
        }
    }

    private Vector2 GetRandomPosition()
    {
        float minX = Mathf.Min(corner1.x, corner2.x);
        float maxX = Mathf.Max(corner1.x, corner2.x);
        float minY = Mathf.Min(corner1.y, corner2.y);
        float maxY = Mathf.Max(corner1.y, corner2.y);

        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        return new Vector2(x, y);

    }


}
