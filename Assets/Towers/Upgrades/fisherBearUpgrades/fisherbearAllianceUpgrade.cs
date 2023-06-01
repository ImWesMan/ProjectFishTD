using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fisherbearAllianceUpgrade : Upgrade
{
    GameObject levelManager;
    int previousFisherbearCount;
    // Start is called before the first frame update
    void Start()
    {
        this.cost = 1200;
        this.name = "Fisherbear Alliance";
        this.effectString = "Fisherbear gains attack speed and damage for every other fisherbear in its range.";
        this.parent = gameObject;
        this.upgradeSprite = null;
        this.path = 1;
        this.numberOnPath = 3;
        levelManager = GameObject.Find("levelManager");
        previousFisherbearCount = 0;
        //Sprite abilityIcon = Resources.Load("rapidReels2", typeof(Sprite)) as Sprite;
        //this.icon = abilityIcon;
    }
    
    void Update()
    {
        applyUpgrade();
    }

    public override void applyUpgrade()
    {
        int fisherbearCount = 0;
        GameObject[] fisherbearObjects = GameObject.FindGameObjectsWithTag("fisherbear");
        foreach (GameObject tower in fisherbearObjects)
        {
            if (tower != gameObject && Vector3.Distance(transform.position, tower.transform.position) <= gameObject.GetComponent<Tower>().attackRange)
            {
                fisherbearCount++;
            }
        }
        Debug.Log(fisherbearCount);
        int countDifference = fisherbearCount - previousFisherbearCount;
        previousFisherbearCount = fisherbearCount; // Update the previous count
        gameObject.GetComponent<Tower>().attackSpeed -= countDifference * 0.025f;
        gameObject.GetComponent<Tower>().attackDamage += countDifference * 3;
    }
    public override bool checkCost()
    {
        if(levelManager.GetComponent<levelManager>().money < this.cost)
            return false;
        else
            return true;
    }
    
}
