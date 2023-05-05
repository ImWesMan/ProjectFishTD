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
        this.attackSpeed = 1;
    }

    void Update()
    {
        base.Update();
    }

}
