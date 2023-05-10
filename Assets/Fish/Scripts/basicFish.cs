using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicFish : Fish
{
    void Awake() 
    {
        this.movementSpeed = 3.0f;
        this.worthAmount = 5;
        this.lifeCost = 1;
        this.fishName = "Fish";
        this.life = 10.00f;
        this.armor = 0.00f;
    }
}
