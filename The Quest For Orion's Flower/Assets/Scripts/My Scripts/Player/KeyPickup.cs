﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    // Temple Key Bools
    public static bool ForestKey;
    public static bool FrostKey;
    public static bool DesertKey;

    // Temple Orb Bools
    public static bool ForestOrb;
    public static bool FrostOrb;
    public static bool DesertOrb;
    public static bool AllOrbs;
    public static bool OrionFlower;

    // Weapon Pickup Bools
    public static bool BowPickup;
    public static bool SwordPickup;

    //Unity References
    public AudioClip Keys;
    public AudioClip OrbPickup;
    public AudioClip Pickup;

    public void Start() // Set all bools to False on Start
    {
        ForestKey = false;
        FrostKey = false;
        DesertKey = false;

        ForestOrb = false;
        FrostOrb = false;
        DesertOrb = false;
        AllOrbs = false;

        SwordPickup = false;
        BowPickup = false;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("ForestKey"))
        {
            AudioSource.PlayClipAtPoint(Keys, this.gameObject.transform.position);
            ForestKey = true;
            Destroy(GameObject.FindWithTag("ForestKey"));
        }

        if (collision.gameObject.tag.Equals("FrostKey"))
        {
            AudioSource.PlayClipAtPoint(Keys, this.gameObject.transform.position);
            FrostKey = true;
            Destroy(GameObject.FindWithTag("FrostKey"));
        }

        if (collision.gameObject.tag.Equals("DesertKey"))
        {
            AudioSource.PlayClipAtPoint(Keys, this.gameObject.transform.position);
            DesertKey = true;
            Destroy(GameObject.FindWithTag("DesertKey"));
        } // When Player collides with Temple Keys, Remove object, Temple Key Bools are set to True, Play sound effect!


        if (collision.gameObject.tag.Equals("ForestOrb"))
        {
            AudioSource.PlayClipAtPoint(OrbPickup, this.gameObject.transform.position);
            ForestOrb = true;
            Destroy(GameObject.FindWithTag("ForestOrb"));
        }

        if (collision.gameObject.tag.Equals("FrostOrb"))
        {
            AudioSource.PlayClipAtPoint(OrbPickup, this.gameObject.transform.position);
            FrostOrb = true;
            Destroy(GameObject.FindWithTag("FrostOrb"));
        }

        if (collision.gameObject.tag.Equals("DesertOrb"))
        {
            AudioSource.PlayClipAtPoint(OrbPickup, this.gameObject.transform.position);
            DesertOrb = true;
            Destroy(GameObject.FindWithTag("DesertOrb"));
        }

        if (collision.gameObject.tag.Equals("OrionFlower"))
        {
            AudioSource.PlayClipAtPoint(OrbPickup, this.gameObject.transform.position);
            OrionFlower = true;
            Destroy(GameObject.FindWithTag("OrionFlower"));
        } // When Player collides with Temple Orbs, Remove object, Temple Orb Bools are set to True, Play sound effect!

        if (collision.tag == "Sword")
        {
            AudioSource.PlayClipAtPoint(Pickup, this.gameObject.transform.position); // When Player collides with Sword, Play sound effect
            SwordPickup = true; // SwordPickup bool is set to true
            Destroy(GameObject.FindWithTag("Sword")); // Destroy Sword gameObject
        }


        if (collision.tag == "Bow")
        {
            AudioSource.PlayClipAtPoint(Pickup, this.gameObject.transform.position); // When Player collides with Bow, Play sound effect
            BowPickup = true; // BowPickup bool is set to true
            Destroy(GameObject.FindWithTag("Bow")); // Destroy Bow gameObject
        }
    }

    public void Update()
    {
        if (ForestOrb == true && FrostOrb == true && DesertOrb == true)
        {
            AllOrbs = true; // If all Forest Orb bools are equal to True, AllOrbs bool is equal to True
        }
    }

}
