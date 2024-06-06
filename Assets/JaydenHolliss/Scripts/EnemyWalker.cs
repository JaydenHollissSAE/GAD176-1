using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

public class EnemyWalker : SimpleBaseEnemy
{
    private GameObject playerObject;

    [SerializeField] float damage = 10.0f;
    bool damageBuffer = false;


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
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, playerObject.transform.position, Time.deltaTime * 5.5f);
            transform.LookAt(playerObject.transform.position);
        }

        //Debug.Log(playerObject.transform.rotation);

        //Artifical Collision and Damage
        if (distance < 1.0f && !damageBuffer)
        {
            playerObject.GetComponent<Health>().TakeDamage(damage, gameObject);
            StartCoroutine(DamagePause());
        }

    }

    private IEnumerator DamagePause()
    {
        damageBuffer = true;
        yield return new WaitForSeconds(0.8f);
        damageBuffer = false;
    }
}
