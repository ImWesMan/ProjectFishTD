using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] public Transform[] points;
    [SerializeField] public Vector2[] vectors;
    public int pointsIndex;
}
