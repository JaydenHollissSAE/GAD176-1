using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float varyDistance;
    private Vector3 spawnPos;
    private int spawnAmount;
    [SerializeField] List<GameObject> enemyList = new List<GameObject>();
    [SerializeField] int maxEnemies;
    [SerializeField] int minEnemies;
    private int xSide;
    private int zSide;

    private void Start()
    {
        StartSpawn();
    }
    public void StartSpawn()
    {
        spawnAmount = Random.Range(minEnemies, maxEnemies);
        for (int i = 0; i < spawnAmount; i++)
        {

            xSide = Random.Range(0, 100);
            //Debug.Log("xSide");
            zSide = Random.Range(0, 100);
            //Debug.Log("zSide");
            if (zSide < 50)
            {
                zSide = -1;
            }
            else
            {
                zSide = 1;
            }
            if (xSide < 50)
            {
                xSide = -1;
            }
            else
            {
                xSide = 1;
            }
            //Debug.Log("xSide is: "+xSide+" zSide is: "+zSide);
            spawnPos = new Vector3(transform.position.x + (Random.Range(1f, varyDistance)) * xSide, transform.position.y, transform.position.z + (Random.Range(1f, varyDistance)) * zSide); //Gets a new random position for the coin to spawn on the map.
            Instantiate(enemyList[Random.Range(0, enemyList.Count)], spawnPos, Quaternion.identity);
            //Debug.Log("Enemy Spawned at: "+spawnPos);
        }
    }

}
