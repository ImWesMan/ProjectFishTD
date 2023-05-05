using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roundManager : MonoBehaviour
{
    public int currentRound;
    public bool autoStart = false;
    [SerializeField]
    public Button startButton;
    public bool roundOver = false;
    // Start is called before the first frame update
    void Start()
    {
        currentRound = 1;
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    void startButtonPressed()
    {
        roundOver = false;
        
    }
}
