using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harpoonSlow : MonoBehaviour
{
    public float duration;
    public float slowAmount;
    private static float originalSpeed;
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
            gameObject.GetComponent<FishMovement>().moveSpeed = originalSpeed;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(this);
        }
    }
    
    public void ApplyEffect()
    {
        if (originalSpeed == 0) {
            originalSpeed = gameObject.GetComponent<FishMovement>().moveSpeed;
        }
        // Reduce the speed of the fish
        gameObject.GetComponent<FishMovement>().moveSpeed *= 1 - slowAmount;
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        // Reset the remaining duration of the effect
        remainingDuration = duration;
    }
}