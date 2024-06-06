using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalker : SimpleBaseEnemy
{
    private GameObject playerObject;

    // Start is called before the first frame update
    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        float distance = Vector3.Distance(this.transform.position, playerObject.transform.position);
        //Debug.Log(distance);
        if (distance < 15.0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, Time.deltaTime * 5.5f);
        }


    }
}
