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

    void Awake() 
    {
        this.attackDamage = 10;
        this.attackRange = 4;
        this.attackSpeed = 0.75f;
        this.rotates = true;
        this.towerCost = 850;
        this.animated = true;
        this.towerName = "Fisherbear";
        this.sellAmount = 595;
    }

    void Update()
    {
        base.Update();
    }

}
