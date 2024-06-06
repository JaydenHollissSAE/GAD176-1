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
        StartCoroutine(SpawnWorld());
    }

    IEnumerator SpawnWorld()
    {
        yield return new WaitForSeconds(0.0f);
        worldSpawn = new Vector3(0.0f, 0.0f, 0.0f);
        Instantiate(WorldPrefab, worldSpawn, Quaternion.identity);
    }
}
