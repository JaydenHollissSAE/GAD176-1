using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private int playerSpawn;
    private List<Vector3> playerSpawnPos = new List<Vector3>();
    private GameObject playerObject;
    private Vector3 tmpVector;
    [SerializeField] List<float> spawnX = new List<float>();
    [SerializeField] List<float> spawnY = new List<float>();
    [SerializeField] List<float> spawnZ = new List<float>();

    void Start()
    {
        for (int i = 0; i < spawnX.Count; i++) //Performs a loop while i is below the length of the spawnX list.
        {
            tmpVector = new Vector3(spawnX[i], spawnY[i]+5f, spawnZ[i]); //Creates a vector based on the spawn axis at i.
            playerSpawnPos.Add(tmpVector); //Adds the created vector to the playerSpawnPos list to make it an option to spawn at.
        }
        //tmpVector = new Vector3(6f, -19f, 9f); //Manually creates a vector for a spawn location.
        //playerSpawnPos.Add(tmpVector); //Adds the created vector to the playerSpawnPos list to make it an option to spawn at.
        //tmpVector = new Vector3(-25.53f, -19.664f, 2f); //Manually creates a vector for a spawn location.
        //playerSpawnPos.Add(tmpVector); //Adds the created vector to the playerSpawnPos list to make it an option to spawn at.
        //tmpVector = new Vector3(24.37f, -21.7f, 8.24f); //Manually creates a vector for a spawn location.
        //playerSpawnPos.Add(tmpVector); //Adds the created vector to the playerSpawnPos list to make it an option to spawn at.
        //tmpVector = new Vector3(58.72f, -27.88f, 25.24f); //Manually creates a vector for a spawn location.
        //playerSpawnPos.Add(tmpVector); //Adds the created vector to the playerSpawnPos list to make it an option to spawn at.
        //Debug.Log(playerSpawnPos.Count); //Prints the amount of items in the playerSpawnPos list to the console for debugging.
        //for (int i = 0;i < playerSpawnPos.Count; i++) //Performs a loop while i is smaller than the amount of items in playerSpawnPos for debugging.
        //{
        //    Debug.Log(playerSpawnPos[i]); //Prints the item in playerSpawnPos at i to the console for debugging.
        //}

        playerObject = GameObject.FindGameObjectWithTag("Player"); //Finds the player's object based on the player tag.
        playerSpawn = Random.Range(0, playerSpawnPos.Count); //Picks a random number between 0 and the amount of items in playerSpawnPos to be used in spawning the player.
        //Debug.Log(playerSpawn); //Prints the selected random number to the console for debugging.
        playerObject.transform.position = playerSpawnPos[playerSpawn]; //Moves the player object to the vector at the random number in playerSpawnPos.
    }
}
