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
            slowEffect.duration = 2.0f;
            slowEffect.slowAmount = 0.3f;
            slowEffect.ApplyEffect();
        }
        else {
            // If the fish already has a slow effect, just reset its remaining duration
            slowEffect.remainingDuration = slowEffect.duration;
        }
        //Do damage to the fish
        DamageFish(fish, gameObject.GetComponent<Tower>().attackDamage);
        Debug.Log("PolarHarpooner is attacking!!!!");
    
    }


    void Awake() 
    {
        this.attackDamage = 12;
        this.attackRange = 5;
        this.attackSpeed = 1.75f;
    }
    
    void Update() 
    {
        base.Update();
    }
   
}
