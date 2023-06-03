using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostFish : Fish
{
    void Awake() 
    {
        this.movementSpeed = 2.95f;
        this.worthAmount = 8;
        this.lifeCost = 4;
        this.fishName = "Ghost Fish";
        this.life = 20.00f;
        this.armor = 0.00f;
        this.isHidden = true;
        this.deathSound = GameObject.Find("fishCaught").GetComponent<AudioSource>();
    }
}
