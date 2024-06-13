using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

public class EnemyBomb : EnemyWalker
{
    private GameObject playerObject;
    [SerializeField] GameObject ExplodeEffect;

    [SerializeField] float deathDamage = 15.0f;
    Vector3 largePopScale = new Vector3(12.0f, 12.0f, 12.0f);
    Vector3 smallPopScale = new Vector3(0.2f, 0.2f, 0.2f);
    [SerializeField] bool death = false;


    // Start is called before the first frame update
    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        float distance = Vector3.Distance(this.transform.position, playerObject.transform.position);
        if (distance < 1.0f && !death)
        {
            //Debug.Log("Distance Reached");
            StartCoroutine(BombExplode());
        }

    }
    private IEnumerator BombExplode()
    {
        death = true;
        //Debug.Log("Begin Death");
        transform.localScale = Vector3.Scale(transform.localScale, Vector3.one + (largePopScale - transform.localScale) * 10.0f * Time.deltaTime);
        //yield return new WaitForSeconds(1.0f);
        transform.localScale = Vector3.Scale(transform.localScale, Vector3.one + (smallPopScale - transform.localScale) * 6.0f * Time.deltaTime);
        //yield return new WaitForSeconds(1.0f);
        playerObject.GetComponent<Health>().TakeDamage(deathDamage, gameObject);
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Health>().TakeDamage(100f, gameObject);
        Instantiate(ExplodeEffect, transform.position, Quaternion.identity);
    }

}
