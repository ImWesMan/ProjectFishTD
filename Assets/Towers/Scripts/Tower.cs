using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public float attackDamage;
    public float attackRange;
    public float attackSpeed;
    private float attackTimer;
    public abstract void Attack(GameObject fish);

    //See tower ranges for debug purposes
    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void Start()
    {
        attackTimer = attackSpeed;
    }

    public void Update()
    {
        // Check for fish in attack range and attack if timer is up
        if (attackTimer >= attackSpeed)
        {
            checkCloseToTag("Fish");
        }
        else
        {
            // Update the attack timer
            attackTimer += Time.deltaTime;
        }
    }

    protected void checkCloseToTag(string tag) 
    {
        GameObject[] fishes = GameObject.FindGameObjectsWithTag(tag);
        foreach(GameObject fish in fishes) {
            float distance = Vector3.Distance(transform.position, fish.transform.position);
            if(distance <= attackRange)
            {
                Attack(fish);
                attackTimer = 0.0f; // Reset the attack timer
                break; // Only attack one fish per frame
            }
        }
    }

    protected void DamageFish(GameObject fish, float damage)
    {
        fish.GetComponent<Fish>().life -= damage;
        if(fish.GetComponent<Fish>().life <= 0)
        {
            //THIS IS WHERE MONEY WOULD BE ADDED TO PLAYER
            Debug.Log("A fish died");
            Destroy(fish);
        }
    }

}
