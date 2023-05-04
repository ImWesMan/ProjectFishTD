using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] public Transform[] points;
    [SerializeField] public Vector2[] vectors;
    public int pointsIndex;

    public void Start()
    {
        GameObject waypointContainer = GameObject.Find("Waypoints");
        points = new Transform[waypointContainer.transform.childCount];
        for (int i = 0; i < waypointContainer.transform.childCount; i++) {
            GameObject waypoint = waypointContainer.transform.GetChild(i).gameObject;
            points[i] = waypoint.transform;

        }
    }
}
