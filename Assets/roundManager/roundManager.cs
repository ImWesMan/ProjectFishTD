using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roundManager : MonoBehaviour
{
    public GameObject levelManager;
    public int currentRound;
    public bool autoStart = false;
    public bool faster = false;
    [SerializeField]
    public Button startButton;
    public bool checkingForRoundEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        currentRound = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(checkingForRoundEnd)
        {
        if(gameObject.GetComponent<fishSpawner>().doneSpawning == true && GameObject.FindGameObjectsWithTag("Fish").Length == 0 && autoStart == false)
        {
            Debug.Log("Round" + currentRound + "Over.");
            levelManager.GetComponent<levelManager>().addMoney(100 + currentRound);
            currentRound++;
            startButton.interactable = true;
            checkingForRoundEnd = false;
        }
        else if(gameObject.GetComponent<fishSpawner>().doneSpawning == true && GameObject.FindGameObjectsWithTag("Fish").Length == 0 && autoStart == true)
        {
            Debug.Log("Round" + currentRound + "Over.");
            levelManager.GetComponent<levelManager>().addMoney(100 + currentRound);
            currentRound++;
            checkingForRoundEnd = false;
            startButtonPressed();
        }
        }
    }

    public void startButtonPressed()
    {
        levelManager.GetComponent<levelManager>().updateRoundText();
        checkingForRoundEnd = true;
        gameObject.GetComponent<fishSpawner>().startRound(currentRound);
    }
}
