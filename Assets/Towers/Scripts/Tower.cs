using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public int attackDamage;
    public int attackRange;
    public int attackSpeed;

    public abstract void Attack(GameObject fish);

    protected void checkCloseToTag(string tag) 
    {
        GameObject[] fishes = GameObject.FindGameObjectsWithTag(tag);
        foreach(GameObject fish in fishes) {
            if(Mathf.Abs(fish.transform.position.x - gameObject.transform.position.x) < this.attackRange &&
                Mathf.Abs(fish.transform.position.y - gameObject.transform.position.y) < this.attackRange)
            {
                Attack(fish);
            }
        }
    }
}
