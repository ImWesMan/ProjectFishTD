using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class fisherbearsPatienceUpgrade : Upgrade
{
    GameObject levelManager;
    // Start is called before the first frame update
    void Start()
    {
        this.cost = 500;
        this.name = "Fisherbear's Patience";
        this.effectString = "Further increase Fisherbear's damage";
        this.parent = gameObject;
        this.upgradeSprite = null;
        this.path = 2;
        this.numberOnPath = 1;
        levelManager = GameObject.Find("levelManager");
    }

    public override void applyUpgrade()
    {
        levelManager.GetComponent<levelManager>().subtractMoney(this.cost);
        gameObject.GetComponent<Tower>().attackDamage = 18.0f;
    }
    public override bool checkCost()
    {
        if(levelManager.GetComponent<levelManager>().money < this.cost)
            return false;
        else
            return true;
    }
    
}
