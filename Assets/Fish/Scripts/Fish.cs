using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    public AudioSource deathSound;
    public float movementSpeed;
    public int worthAmount;
    public int lifeCost;
    public string fishName;
    public float life;
    public float armor;
    public bool hasArmor;
    public int waypointIncrement;
    [SerializeField]
    public float percentageProgress;
    void Start()
    {
        waypointIncrement = 100/gameObject.GetComponent<FishMovement>().path.GetComponent<Path>().points.Length;
        if(armor > 0)
        {
            hasArmor = true;
        }
    }

    public void IncrementPercentage()
    {
        percentageProgress += waypointIncrement;
    }

    public float GetCurrentPercentage()
    {
        return percentageProgress;
    }
}
