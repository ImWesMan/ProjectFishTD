using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
   Vector3 waypointPos;
   [SerializeField]
   public GameObject nextWaypoint;

   void Start()
   {
    this.waypointPos = gameObject.transform.position;
   }
}
