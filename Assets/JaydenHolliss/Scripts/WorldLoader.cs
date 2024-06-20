using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLoader : MonoBehaviour
{
    [SerializeField] GameObject WorldPrefab;
    private Vector3 worldSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWorld()); //Runs the SpawnWorld function to spawn in the prebuilt world prefab.
    }

    IEnumerator SpawnWorld()
    {
        yield return new WaitForSeconds(0.0f); //Waits for 0 seconds, required to prevent Unity from killing itself when running function.
        worldSpawn = new Vector3(0.0f, 0.0f, 0.0f); //Sets the world spawn location to 0, 0, 0.
        Instantiate(WorldPrefab, worldSpawn, Quaternion.identity); //Spawns the world prefab at the spawn location.
    }
}
