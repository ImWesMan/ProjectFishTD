using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class biggerSpoolsUpgrade : Upgrade
{
    GameObject levelManager;
    // Start is called before the first frame update
    void Start()
    {
        this.cost = 450;
        this.name = "Bigger Spools";
        this.effectString = "Increase Fisherbears range";
        this.parent = gameObject;
        this.upgradeSprite = null;
        this.path = 1;
        this.numberOnPath = 0;
        levelManager = GameObject.Find("levelManager");
    }

    public override void applyUpgrade()
    {
        levelManager.GetComponent<levelManager>().subtractMoney(this.cost);
        gameObject.GetComponent<Tower>().attackRange = 5.0f;
        gameObject.GetComponent<Tower>().recalculateRangeRadius();
    }
    public override bool checkCost()
    {
        if(levelManager.GetComponent<levelManager>().money < this.cost)
            return false;
        else
            return true;
    }
    
}
