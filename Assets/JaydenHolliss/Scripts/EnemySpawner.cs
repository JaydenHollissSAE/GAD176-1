using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float roomPos;
    [SerializeField] float varyDistance;
    private int spawnAmount;
    private int spawnCount;
    private List<Vector3> playerSpawnPos = new List<Vector3>();
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
