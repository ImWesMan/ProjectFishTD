using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behemothFish : Fish
{
    void Awake() 
    {
        this.movementSpeed = 3;
        this.worthAmount = 8;
        this.lifeCost = 2;
        this.fishName = "Behemoth Fish";
        this.life = 20.00f;
        this.armor = 0.00f;
    }
}
