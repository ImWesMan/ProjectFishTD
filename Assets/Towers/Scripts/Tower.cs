using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public float attackDamage;
    public float attackRange;
    public float attackSpeed;
    private float attackTimer;
    [SerializeField]
    public GameObject[] targets;
    public abstract void Attack(GameObject fish);
    public string targetMode = "First";

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
        targets = GameObject.FindGameObjectsWithTag("Fish");
        sortTargets();
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
         // Attack the first target in range
        foreach(GameObject target in targets) {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if(distance <= attackRange)
            {
                Attack(target);
                attackTimer = 0.0f; // Reset the attack timer
                break; // Only attack one target per frame
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

    public void sortTargets()
    {
         // Sort the targets by currentPercentage and distance to the next waypoint
        if(targetMode == "First")
        {
        System.Array.Sort(targets, (x, y) =>
        {
            float distanceToNextWaypointX = Vector3.Distance(x.transform.position, x.GetComponent<FishMovement>().GetNextPosition());
            float distanceToNextWaypointY = Vector3.Distance(y.transform.position, y.GetComponent<FishMovement>().GetNextPosition());

            float currentPercentageX = x.GetComponent<Fish>().GetCurrentPercentage();
            float currentPercentageY = y.GetComponent<Fish>().GetCurrentPercentage();

            int comparison = currentPercentageY.CompareTo(currentPercentageX);
            if (comparison != 0)
            {
                return comparison;
            }
            else
            {
                return distanceToNextWaypointX.CompareTo(distanceToNextWaypointY);
            }
        });
        }
    }
}
