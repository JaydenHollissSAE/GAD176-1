using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    private bool buffer;
    private EnemySpawner enemySpawner;

    // Update is called once per frame
    void Update()
    {
        if (!buffer)
        StartCoroutine(SpawnerFunction());
    }
    private IEnumerator SpawnerFunction()
    {
        buffer = true;
        yield return new WaitForSeconds(15.0f);
        enemySpawner.StartSpawn();
        buffer = false;
    }
}
