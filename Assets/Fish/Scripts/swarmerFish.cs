using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swarmerFish : Fish
{
    void Awake() 
    {
        this.movementSpeed = 3.65f;
        this.worthAmount = 6;
        this.lifeCost = 3;
        this.fishName = "Swarmer Fish";
        this.life = 20.00f;
        this.armor = 0.00f;
        this.deathSound = GameObject.Find("fishCaught").GetComponent<AudioSource>();
    }
}
