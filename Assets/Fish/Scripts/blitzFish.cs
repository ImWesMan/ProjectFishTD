using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blitzFish : Fish
{
    void Awake() 
    {
        this.movementSpeed = 5.0f;
        this.worthAmount = 14;
        this.lifeCost = 3;
        this.fishName = "Blitz Fish";
        this.life = 15.00f;
        this.armor = 0.00f;
        this.deathSound = GameObject.Find("fishCaught").GetComponent<AudioSource>();
    }
}
