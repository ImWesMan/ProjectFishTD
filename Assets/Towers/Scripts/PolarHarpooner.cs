using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarHarpooner : Tower
{
    float slowDuration = 2.75f;
    float slowAmount = 0.35f;
    public override void Attack(GameObject fish) 
    {
        // Check if the fish already has a harpoonSlow component attached
        harpoonSlow slowEffect = fish.GetComponent<harpoonSlow>();
        if (slowEffect == null) {
            // If not, add a new component and apply the slow effect
            slowEffect = fish.AddComponent<harpoonSlow>();
            slowEffect.duration = slowDuration;
            slowEffect.slowAmount = slowAmount;
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

    public override void assignUpgrades()
    {
        towerUpgrades = new Upgrade[numOfUpgradePaths][];
         //INITALIZE PATHS WITH LENGTH OF 6 UPGRADES
        for(int i =0; i<numOfUpgradePaths; i++)
        {
            towerUpgrades[i] = new Upgrade[6];
        }
        //ASSIGN UPGRADES
        towerUpgrades[0][0] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[1][0] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[2][0] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[3][0] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[0][1] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[1][1] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[2][1] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[3][1] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[0][2] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[1][2] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[2][2] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[3][2] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[0][3] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[1][3] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[2][3] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[3][3] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[0][4] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[1][4] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[2][4] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[3][4] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[0][5] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[1][5] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[2][5] = gameObject.AddComponent<rapidReelsUpgrade>();
        towerUpgrades[3][5] = gameObject.AddComponent<rapidReelsUpgrade>();
        //
    }
    void Awake() 
    {
        this.attackDamage = 14;
        this.attackRange = 5.5f;
        this.attackSpeed = 1.35f;
        this.rotates = true;
        this.towerCost = 950;
        this.animated = true;
        this.towerName = "Polar Harpooner";
        this.attacks = true;
        this.numOfUpgradePaths = 4;
        assignUpgrades();
    }
    
    void Update() 
    {
        base.Update();
    }
   
}
