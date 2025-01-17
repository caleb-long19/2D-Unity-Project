﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    //Variables
    public int EnemyHealth; // enemy health

    [SerializeField]
    public float EnemySpeed = 5.0f; // Speed of the Enemy

    [SerializeField]
    private float MinEnemyRange = 0; // Minimum range the Enemy can spot player

    [SerializeField]
    private float MaxEnemyRange = 0; // Maximum range the Enemy can spot player

    //Unity References
    public GameObject Blood; // Blood particles for Enemies
    private Animator EnemyMovement; // Reference to Unity Animator
    private Transform Target; // Reference to Player position
    private Vector2 Movement; // Vector (X, Y) for Enemy Movement
    public AudioClip Hurt;


    public void Start()
    {
        EnemyMovement = GetComponent<Animator>(); // EnemyMovement is equal to Animator Component on gameObject
        Target = FindObjectOfType<TopDownCharacterController2D>().transform; // Target is equal to Player
    }


    private void Update()
    {
        if (Vector3.Distance(Target.position, transform.position) <= MaxEnemyRange && Vector3.Distance(Target.position, transform.position) >= MinEnemyRange)
        {
            TrackPlayer(); // If the Players Positon is out of the Enemies Max Range && the Player is above the Enemies Minimum Range, run the Track Player Method
        }

        if (EnemyHealth <= 0)
        {
            Destroy(gameObject); // When EnemyHealth is equal to 0, Destroy Enemy gameObject
            Coin.score += 25; // Add 25 points to Players Score
        }
    }

    public void TrackPlayer()
    {
        EnemyMovement.SetBool("enemyIsMoving", true); // Sets Animator "enemyIsMoving" Parameter to True
        EnemyMovement.SetFloat("Horizontal", (Target.position.x - transform.position.x)); // Enemies Horzontal Position
        EnemyMovement.SetFloat("Vertical", (Target.position.y - transform.position.y)); // Enemies Vertical Position
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, EnemySpeed * Time.deltaTime); // Transforms Enemies Position to Players Position
    }

    public void TakeDamage(int damage) // Method for Enenmies taking damage from Player
    {
        Instantiate(Blood, transform.position, Quaternion.identity); // When Enemy is damaged play blood particle effect
        AudioSource.PlayClipAtPoint(Hurt, this.gameObject.transform.position); // Play Enemy Hurt sound effect when Damaged
        EnemyHealth -= damage; // Enemies Health takes damage from Player

        Debug.Log("Enemy has Taken Damage!"); // Display Debug Log in Console
    }

    public void SetTarget(Transform newTarget)
    {
        Target = newTarget;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Knockback") // If the collision/hit box tag is equal to Knockback
        {
            Vector2 difference = transform.position - collision.transform.position; // Calculate the difference in position for knockback
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y); // When Player deals damage to Enemy, Enemy gets knocked back on the X,Y Axis
        }
    }

}

