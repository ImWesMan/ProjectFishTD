using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fisherbearsLuckUpgrade : Upgrade
{
    GameObject levelManager;
    // Start is called before the first frame update
    void Start()
    {
        this.cost = 900;
        this.name = "Fisherbears Luck";
        this.effectString = "Increase Fisherbears income from caught fish.";
        this.parent = gameObject;
        this.upgradeSprite = null;
        this.path = 0;
        this.numberOnPath = 2;
        levelManager = GameObject.Find("levelManager");
    }

    public override void applyUpgrade()
    {
        levelManager.GetComponent<levelManager>().subtractMoney(this.cost);
        gameObject.GetComponent<Fisherbear>().extraIncome = 3;
    }
    public override bool checkCost()
    {
        if(levelManager.GetComponent<levelManager>().money < this.cost)
            return false;
        else
            return true;
    }
    
}
