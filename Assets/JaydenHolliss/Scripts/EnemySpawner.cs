using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float roomPos;
    [SerializeField] float varyDistance;
    private Vector3 spawnPos;
    private int spawnAmount;
    [SerializeField] List<GameObject> enemyList = new List<GameObject>();
    [SerializeField] int maxEnemies;
    [SerializeField] int minEnemies;

    private void Start()
    {


        spawnAmount = Random.Range(minEnemies, maxEnemies);
        for (int i = 0; i < spawnAmount; i++)
        {
            spawnPos = new Vector3(roomPos+Random.Range(1f, varyDistance), 0f,roomPos + Random.Range(1f, varyDistance)); //Gets a new random position for the coin to spawn on the map.
            Instantiate(enemyList[Random.Range(0,enemyList.Count)], spawnPos, Quaternion.identity);
            Debug.Log("Enemy Spawned");
        }
    }

}
