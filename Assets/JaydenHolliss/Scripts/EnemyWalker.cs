using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

public class EnemyWalker : SimpleBaseEnemy
{
    private GameObject playerObject;

    [SerializeField] float damage = 10.0f;
    bool damageBuffer = false;
    public float distance;
    private bool damaged = false;
    private float preHealth;
    public bool distanceOverride;

    private void Start()
    {
        preHealth = this.GetComponent<Health>().CurrentHealth; //Sets preHealth to the enemy's starting health.

        if (playerObject == null) //Checks if playerObject is connected to anything.
        {
            playerObject = GameObject.FindGameObjectWithTag("Player"); //Finds the player's object based on the Player tag.
        }
    }

    // Update is called once per frame
    private void Update()
    {
        DamageCheck(); //Runs the DamageCheck script to move the enemy if it takes damage.

        WalkToPlayer(); //Runs the WalkToPlayer script to move the enemy towards the player.

        PerformDamage(); //Runs the PerformDamage script to check if the enemy will deal damage to the player or not.

    }

    public void WalkToPlayer()
    {

        distance = Vector3.Distance(this.transform.position, playerObject.transform.position); //Gets the distance of the enemy object from the player object.
        //Debug.Log(distance); //Prints the distance from the player object in the console for debigging.
        if (distance < 15.0f || distanceOverride) //Checks if the distance from the player object is below 15.
        {
            transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, Time.deltaTime * 5.5f); //Moves the enemy object towards the player object's position.
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, playerObject.transform.position, Time.deltaTime * 5.5f); //Rotates the enemy object based on the player object's position. Unneeded so dropped.
            transform.LookAt(playerObject.transform.position); //Rotates the enemy object so the front is looking at the player object's position.
            //Debug.Log(playerObject.transform.rotation); //Prints the player object's rotation to the console for debugging.
        }
    }

    private void DamageCheck()
    {
        if (this.GetComponent<Health>().CurrentHealth < preHealth) //Determines if the enemy has taken damage or not.
        {
            distanceOverride = true; //Toggles distanceOverride to true.
            preHealth = this.GetComponent<Health>().CurrentHealth; //Sets preHealth to the enemy's current health.
            StartCoroutine(DamageAgroBuffer()); //Begins the DamageAgroBuffer function to begin the timer.
        }

    }

    private IEnumerator DamageAgroBuffer()
    {
        WalkToPlayer(); //Runs the WalkToPlayer script to move the enemy towards the player.
        yield return new WaitForSeconds(7.0f); //Waits 7 seconds to determine how long the enemy with track the player for.
        distanceOverride = false; //Sets distanceOverride to false to disable the tracking.
    }

    private IEnumerator DamagePause()
    {
        damageBuffer = true; //Sets damageBuffer to true to prevent the player from being damaged by the enemy.
        yield return new WaitForSeconds(0.8f); //Waits 0.8 seconds to act as a buffer between enemy attacks.
        damageBuffer = false; //Sets damageBuffer to false to allow the enemy to damage the player again.
    }

    protected void PerformDamage()
    {
        /// <summary>
        /// Artifical Collision and Damage
        /// </summary>
        if (distance < 1.0f && !damageBuffer) //Checks if the distance from the player object is smaller than 1 and if damageBuffer is false.
        {
            playerObject.GetComponent<Health>().TakeDamage(damage, gameObject); //Inflicts damage to the player based on the damage variable.
            StartCoroutine(DamagePause()); //Begins the DamagePause function to give a buffer between damage.
        }
    }
}
