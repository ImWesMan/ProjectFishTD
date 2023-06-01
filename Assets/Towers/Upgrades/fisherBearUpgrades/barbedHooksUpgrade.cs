using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class barbedHooksUpgrade : Upgrade
{
    GameObject levelManager;
    // Start is called before the first frame update
    void Start()
    {
        this.cost = 250;
        this.name = "Barbed Hooks";
        this.effectString = "Increase Fisherbears damage";
        this.parent = gameObject;
        this.upgradeSprite = null;
        this.path = 2;
        this.numberOnPath = 0;
        levelManager = GameObject.Find("levelManager");
    }

    public override void applyUpgrade()
    {
        levelManager.GetComponent<levelManager>().subtractMoney(this.cost);
        gameObject.GetComponent<Tower>().attackDamage = 14.0f;
    }
    public override bool checkCost()
    {
        if(levelManager.GetComponent<levelManager>().money < this.cost)
            return false;
        else
            return true;
    }
    
}
