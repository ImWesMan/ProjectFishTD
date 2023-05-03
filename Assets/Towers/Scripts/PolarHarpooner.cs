using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarHarpooner : Tower
{
    public override void Attack(GameObject fish) 
    {
        // Check if the fish already has a harpoonSlow component attached
        harpoonSlow slowEffect = fish.GetComponent<harpoonSlow>();
        if (slowEffect == null) {
            // If not, add a new component and apply the slow effect
            slowEffect = fish.AddComponent<harpoonSlow>();
            slowEffect.duration = 1.0f;
            slowEffect.slowAmount = 0.5f;
            slowEffect.ApplyEffect();
        }
        else {
            // If the fish already has a slow effect, just reset its remaining duration
            slowEffect.remainingDuration = slowEffect.duration;
        }
    
        Debug.Log("PolarHarpooner is attacking!!!!");
    
    }


    void Awake() 
    {
        this.attackDamage = 15;
        this.attackRange = 5;
        this.attackSpeed = 2;
    }
    
    void Update() 
    {
        base.Update();
    }
   
}
