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
        playerObject = GameObject.FindGameObjectWithTag("Player"); //Gets the player's object based on the Player tag.
    }

    // Update is called once per frame
    private void Update()
    {
        float distance = Vector3.Distance(this.transform.position, playerObject.transform.position); //Gets the distance between the enemy object and the player object.
        if (distance < 1.0f && !death) //Checks if the distance is below 1 and if the death sequence flag is false.
        {
            //Debug.Log("Distance Reached"); //Prints a message to the console for debugging.
            StartCoroutine(BombExplode()); //Runs the BombExpload function.
        }

    }
    private IEnumerator BombExplode()
    {
        death = true; //Sets death to true to prevent the function from being triggered multiple times and breaking.
        //Debug.Log("Begin Death"); //Prints a message to the console for debugging.
        transform.localScale = Vector3.Scale(transform.localScale, Vector3.one + (largePopScale - transform.localScale) * 10.0f * Time.deltaTime); //Scales the enemy object to 12 as determined by largePopScale.
        //yield return new WaitForSeconds(1.0f); //Waits 1 second. Broke function so dropped.
        transform.localScale = Vector3.Scale(transform.localScale, Vector3.one + (smallPopScale - transform.localScale) * 6.0f * Time.deltaTime); //Scales the enemy object to 0.2 as determined by smallPopScale.
        //yield return new WaitForSeconds(1.0f); //Waits 1 second. Broke function so dropped.
        playerObject.GetComponent<Health>().TakeDamage(deathDamage, gameObject); //Causes the player to take damage based on the deathDamage variable.
        yield return new WaitForSeconds(0.1f); //Waits for 0.1 seconds.
        gameObject.GetComponent<Health>().TakeDamage(100f, gameObject); //Deals 100 damage to the enemy to trigger all the functions associated with the enemy's death.
        Instantiate(ExplodeEffect, transform.position, Quaternion.identity); //Spawns an exposion effect where the enemy died.
    }

}
