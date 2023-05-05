using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harpoonSlow : MonoBehaviour
{
    public float duration;
    public float slowAmount;
    [SerializeField]
    public float originalSpeed;
    public float remainingDuration;

    void Start()
    {
        // Set the remaining duration of the effect
        remainingDuration = duration;
    }
    
    void Update()
    {
        // Decrease the remaining duration each frame
        remainingDuration -= Time.deltaTime;
        
        // If the effect has expired, reset the speed of the fish
        if (remainingDuration <= 0)
        {
            gameObject.GetComponent<Fish>().movementSpeed = originalSpeed;
            Destroy(this);
        }
    }
    
    public void ApplyEffect()
    {
        if (originalSpeed == 0) {
            originalSpeed = gameObject.GetComponent<Fish>().movementSpeed;
        }
        // Reduce the speed of the fish
        gameObject.GetComponent<Fish>().movementSpeed *= 1 - slowAmount;
        // Reset the remaining duration of the effect
        remainingDuration = duration;
    }
}