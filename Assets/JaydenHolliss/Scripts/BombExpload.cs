using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(BombExplodeFunc()); //Runs the DelayDelete function.
    }


    IEnumerator BombExplodeFunc()
    {
        yield return new WaitForSeconds(0.5f); //Waits 1 second.
        Destroy(this.gameObject); //Removes the pop effect from the scene.
    }
}