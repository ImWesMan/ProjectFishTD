using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public float attackDamage;
    public float attackRange;
    public float attackSpeed;
    public abstract void Attack(GameObject fish);

    //See tower ranges for debug purposes
    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    protected void checkCloseToTag(string tag) 
    {
        GameObject[] fishes = GameObject.FindGameObjectsWithTag(tag);
        foreach(GameObject fish in fishes) {
            float distance = Vector3.Distance(transform.position, fish.transform.position);
            if(distance <= attackRange)
            {
                Attack(fish);
            }
        }
    }

}
