using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisherbear : Tower
{

    public override void Attack(GameObject fish) 
    {
        DamageFish(fish, gameObject.GetComponent<Tower>().attackDamage);
        Debug.Log("Fisherbear is attacking!!!!");
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
        towerUpgrades[0][0] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[1][0] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[2][0] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[3][0] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[0][1] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[1][1] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[2][1] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[3][1] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[0][2] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[1][2] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[2][2] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[3][2] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[0][3] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[1][3] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[2][3] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[3][3] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[0][4] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[1][4] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[2][4] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[3][4] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[0][5] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[1][5] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[2][5] = gameObject.AddComponent<attackSpeedUpgrade>();
        towerUpgrades[3][5] = gameObject.AddComponent<attackSpeedUpgrade>();

        //

    }
    void Awake() 
    {
        this.attackDamage = 10;
        this.attackRange = 4;
        this.attackSpeed = 0.75f;
        this.rotates = true;
        this.towerCost = 850;
        this.animated = true;
        this.towerName = "Fisherbear";
        this.attacks = true;
        this.numOfUpgradePaths = 4;
        assignUpgrades();
    }

    void Update()
    {
        base.Update();
    }

}
