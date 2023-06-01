using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class fisherbearsDomainUpgrade : Upgrade
{
    GameObject levelManager;
    // Start is called before the first frame update
    void Start()
    {
        this.cost = 450;
        this.name = "Fisherbear's Domain";
        this.effectString = "Further increase Fisherbear's range";
        this.parent = gameObject;
        this.upgradeSprite = null;
        this.path = 1;
        this.numberOnPath = 1;
        levelManager = GameObject.Find("levelManager");
    }

    public override void applyUpgrade()
    {
        levelManager.GetComponent<levelManager>().subtractMoney(this.cost);
        gameObject.GetComponent<Tower>().attackRange = 6.0f;
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
