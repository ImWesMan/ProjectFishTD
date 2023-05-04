using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField]
    public GameObject path;
    private int index;

    public Vector3 GetNextPosition() {
        return path.GetComponent<Path>().points[index].transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
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
                //SUBTRACT LIVES, ETC
                Destroy(gameObject);
                Debug.Log("Reached the end of the path!");
            }
        }
    }
}
