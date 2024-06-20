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


        spawnAmount = Random.Range(minEnemies, maxEnemies); //Gets a random variable based on the minEnemies and maxEnemies variables to determine the amount of enemies that will be spawned.
        for (int i = 0; i < spawnAmount; i++) //Performs a loop while i is smaller than spawnAmount.
        {

            /// <summary>
            /// Unity random didn't give nice numbers for variables from -1 to 1 so a larger range is used to help determine it.
            /// </summary>

            xSide = Random.Range(0, 100); //Sets xSide to a random number from 0 to 100.
            //Debug.Log("xSide"); //Prints a message to the console for debugging.
            zSide = Random.Range(0, 100); //Sets zSide to a random number from 0 to 100.
            //Debug.Log("zSide"); //Prints a message to the console for debugging.
            if (zSide < 50) //Checks if zSide is below 50.
            {
                zSide = -1; //Sets zSide to -1.
            }
            else //If zSide was 50 or above.
            {
                zSide = 1; //Sets zSide to 1.
            }
            if (xSide < 50) //Checks if xSide is below 50.
            {
                xSide = -1; //Sets xSide to -1.
            }
            else //If xSide was 50 or above.
            {
                xSide = 1; //Sets xSide to 1.
            }
            //Debug.Log("xSide is: "+xSide+" zSide is: "+zSide); //Prints xSide and zSide to the console for debugging.
            spawnPos = new Vector3(transform.position.x+(Random.Range(1f, varyDistance))*xSide, transform.position.y, transform.position.z + (Random.Range(1f, varyDistance))*zSide); //Gets a random position determined by the spawner's position, zSide, xSide, and varyDistance to give a unique spawning position that goes across a large range within a square.
            Instantiate(enemyList[Random.Range(0,enemyList.Count)], spawnPos, Quaternion.identity); //Spawns a random enemy from enemyList based on the random position.
            //Debug.Log("Enemy Spawned at: "+spawnPos); //Prints the spawn position to the console for debugging.
        }
    }

}
