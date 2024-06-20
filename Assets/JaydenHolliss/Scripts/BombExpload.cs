using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(BombExplodeFunc()); //Runs the BombExplodeFunc function to manage the effect.
    }


    IEnumerator BombExplodeFunc()
    {
        yield return new WaitForSeconds(0.5f); //Waits 0.5 seconds.
        Destroy(this.gameObject); //Removes the effect from the scene.
    }
}