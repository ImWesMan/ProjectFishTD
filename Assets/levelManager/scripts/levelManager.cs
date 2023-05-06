using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class levelManager : MonoBehaviour
{
    public GameObject roundManager;
    public TMP_Text livesText;
    public TMP_Text moneyText;
    public TMP_Text roundText;
    public int lives;
    public int money;
    // Start is called before the first frame update
    void Start()
    {
        lives = 100;
        money = 300;
    }

    public void subtractLives(GameObject fish)
    {
        lives -= fish.GetComponent<Fish>().lifeCost;
        livesText.text = lives.ToString();
        checkGameEnd();
    }

    public void addMoney(GameObject fish)
    {
        money += fish.GetComponent<Fish>().worthAmount;
        moneyText.text = money.ToString();
    }

    public void checkGameEnd()
    {
        if(lives <= 0)
        {
            Debug.Log("GAME IS OVER");
        }
    }

    public void updateRoundText()
    {
        roundText.text = roundManager.GetComponent<roundManager>().currentRound.ToString();
    }
}
