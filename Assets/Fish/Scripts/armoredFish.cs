using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armoredFish : Fish
{
    void Awake() 
    {
        this.movementSpeed = 2.75f;
        this.worthAmount = 9;
        this.lifeCost = 4;
        this.fishName = "Armored Fish";
        this.life = 10.00f;
        this.armor = 30.00f;
        this.deathSound = GameObject.Find("fishCaught").GetComponent<AudioSource>();
    }
}
