using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mechaRodUpgrade : Upgrade
{
    GameObject levelManager;
    // Start is called before the first frame update
    void Start()
    {
        this.cost = 1100;
        this.name = "Mecha Rod";
        this.effectString = "Fisherbear switches from a wooden rod to a mechanical rod.";
        this.parent = gameObject;
        this.upgradeSprite = null;
        this.path = 0;
        this.numberOnPath = 3;
        levelManager = GameObject.Find("levelManager");
    }

    public override void applyUpgrade()
    {
        levelManager.GetComponent<levelManager>().subtractMoney(this.cost);
        gameObject.GetComponent<Tower>().attackSpeed -= gameObject.GetComponent<Tower>().attackSpeed * .15f;
        gameObject.GetComponent<Tower>().attackDamage = 18;
    }
    public override bool checkCost()
    {
        if(levelManager.GetComponent<levelManager>().money < this.cost)
            return false;
        else
            return true;
    }
    
}
