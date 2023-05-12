using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicFish : Fish
{
    void Awake() 
    {
        this.movementSpeed = 3.5f;
        this.worthAmount = 7;
        this.lifeCost = 1;
        this.fishName = "Fish";
        this.life = 10.00f;
        this.armor = 0.00f;
        this.deathSound = GameObject.Find("fishCaught").GetComponent<AudioSource>();
    }
}
