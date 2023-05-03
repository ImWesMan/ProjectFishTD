using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float moveSpeed = 75.0f;
    GameObject currentWaypoint;
    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = GameObject.FindWithTag("SpawnWaypoint");
    }

    // Update is called once per frame
    void Update()
    {
        // calculate the direction to move towards the current waypoint
        Vector3 direction = (currentWaypoint.transform.position - transform.position).normalized;

        // move the enemy towards the current waypoint
        transform.position += direction * moveSpeed * Time.deltaTime;

        // if the enemy is close enough to the current waypoint, set the next waypoint as the current waypoint
        if (Vector3.Distance(transform.position, currentWaypoint.transform.position) < 0.1f)
        {
            if (currentWaypoint.GetComponent<Waypoint>().nextWaypoint != null)
            {
                currentWaypoint = currentWaypoint.GetComponent<Waypoint>().nextWaypoint;
            }
            else
            {
                //SUBTRACT LIVES, ETC
                Destroy(gameObject);
                Debug.Log("Reached the end of the path!");
            }
        }
    }
}
