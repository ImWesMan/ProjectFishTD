using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class attackSpeedUpgrade : Upgrade
{
    GameObject levelManager;
    // Start is called before the first frame update
    void Start()
    {
        this.cost = 300;
        this.name = "Attack Speed";
        this.effectString = "Increase Fisherbears attack speed by 10%";
        this.parent = gameObject;
        this.upgradeSprite = null;
        this.path = 0;
        this.numberOnPath = 0;
        levelManager = GameObject.Find("levelManager");
    }

    public override void applyUpgrade()
    {
        levelManager.GetComponent<levelManager>().subtractMoney(this.cost);
        gameObject.GetComponent<Tower>().attackSpeed -= gameObject.GetComponent<Tower>().attackSpeed * .10f;
    }
    public override bool checkCost()
    {
        if(levelManager.GetComponent<levelManager>().money < this.cost)
            return false;
        else
            return true;
    }
    
}
