using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField]
    public GameObject path;
    [SerializeField]
    private int index;
    public GameObject levelManager;
    public Vector3 GetNextPosition() {
        return path.GetComponent<Path>().points[index].transform.position;
    }

    // Start is called before the first frame update
    void Awake()
    {
        path = GameObject.Find("Path");
    }
    void Start()
    {
        levelManager = GameObject.Find("levelManager");
        path = GameObject.Find("Path");
        moveSpeed = gameObject.GetComponent<Fish>().movementSpeed;
        index = 0;
        //transform.position = Vector3.Mopath.GetComponent<Path>().points[index].transform.position;
        // calculate the direction to move towards the current waypoint
        Vector3 direction = (path.GetComponent<Path>().points[index].transform.position - transform.position).normalized;

        // move the enemy towards the current waypoint
        transform.position += direction * moveSpeed * Time.deltaTime;
        index++;
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = gameObject.GetComponent<Fish>().movementSpeed;
        if(index >= path.GetComponent<Path>().points.Length){
            return;
        }

        // calculate the direction to move towards the current waypoint
        Vector3 direction = (path.GetComponent<Path>().points[index].transform.position - transform.position).normalized;

        // move the enemy towards the current waypoint
        transform.position += direction * moveSpeed * Time.deltaTime;

        // if the enemy is close enough to the current waypoint, set the next waypoint as the current waypoint
        if (Vector3.Distance(transform.position, path.GetComponent<Path>().points[index].transform.position) < 0.1f)
        {
            if (index < path.GetComponent<Path>().points.Length  - 1)
            {
                gameObject.GetComponent<Fish>().IncrementPercentage();
                index++;
            }
            else
            {
                levelManager.GetComponent<levelManager>().subtractLives(gameObject);
                Debug.Log("Reached the end of the path!");
                Destroy(gameObject);
            }
        }
    

        // Normalize the direction vector to ensure consistent rotation
        if (direction.magnitude > 0)
        {
            direction.Normalize();

            // Calculate the angle in degrees between the direction vector and the positive X-axis
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle += 90.0f;
            // Apply the rotation around the Z-axis
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

    }
}
