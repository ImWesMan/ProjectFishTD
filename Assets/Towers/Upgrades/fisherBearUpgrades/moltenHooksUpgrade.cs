using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class moltenHooksUpgrade : Upgrade
{
    GameObject levelManager;
    // Start is called before the first frame update
    void Start()
    {
        this.cost = 800;
        this.name = "Molten Hooks";
        this.effectString = "Allows Fisherbear to hit armor, increases damage";
        this.parent = gameObject;
        this.upgradeSprite = null;
        this.path = 2;
        this.numberOnPath = 2;
        levelManager = GameObject.Find("levelManager");
    }

    public override void applyUpgrade()
    {
        levelManager.GetComponent<levelManager>().subtractMoney(this.cost);
        gameObject.GetComponent<Tower>().hitsArmor = true;
        gameObject.GetComponent<Tower>().attackDamage += 2.0f;
    }
    public override bool checkCost()
    {
        if(levelManager.GetComponent<levelManager>().money < this.cost)
            return false;
        else
            return true;
    }
    
}
