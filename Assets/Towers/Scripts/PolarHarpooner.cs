using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarHarpooner : Tower
{

    public override void Attack(GameObject fish) 
    {
        Destroy(fish);
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
