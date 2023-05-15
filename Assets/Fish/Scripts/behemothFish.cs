using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behemothFish : Fish
{
    void Awake() 
    {
        this.movementSpeed = 2.5f;
        this.worthAmount = 8;
        this.lifeCost = 2;
        this.fishName = "Behemoth Fish";
        this.life = 20.00f;
        this.armor = 0.00f;
        this.deathSound = GameObject.Find("fishCaught").GetComponent<AudioSource>();
    }
}
