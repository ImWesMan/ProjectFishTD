using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blitzFish : Fish
{
    void Awake() 
    {
        this.movementSpeed = 4.0f;
        this.worthAmount = 10;
        this.lifeCost = 3;
        this.fishName = "Blitz Fish";
        this.life = 15.00f;
        this.armor = 0.00f;
        this.deathSound = GameObject.Find("fishCaught").GetComponent<AudioSource>();
    }
}
