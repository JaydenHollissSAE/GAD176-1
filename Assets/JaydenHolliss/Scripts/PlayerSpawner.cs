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
        for (int i = 0; i < spawnX.Count; i++)
        {
            tmpVector = new Vector3(spawnX[i], spawnY[i]+5f, spawnZ[i]);
            playerSpawnPos.Add(tmpVector);
        }
        //tmpVector = new Vector3(6f, -19f, 9f);
        //playerSpawnPos.Add(tmpVector);
        //tmpVector = new Vector3(-25.53f, -19.664f, 2f);
        //playerSpawnPos.Add(tmpVector);
        //tmpVector = new Vector3(24.37f, -21.7f, 8.24f);
        //playerSpawnPos.Add(tmpVector);
        //tmpVector = new Vector3(58.72f, -27.88f, 25.24f);
        //playerSpawnPos.Add(tmpVector);
        //Debug.Log(playerSpawnPos.Count);
        //for (int i = 0;i < playerSpawnPos.Count; i++)
        //{
        //    Debug.Log(playerSpawnPos[i]);
        //}

        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerSpawn = Random.Range(0, 4);
        Debug.Log(playerSpawn);
        playerObject.transform.position = playerSpawnPos[playerSpawn];
    }
}
