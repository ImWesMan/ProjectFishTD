using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class lightweightRodUpgrade : Upgrade
{
    GameObject levelManager;
    // Start is called before the first frame update
    void Start()
    {
        this.cost = 600;
        this.name = "Lightweight Rod";
        this.effectString = "Further increases Fisherbears attack speed by another 15%";
        this.parent = gameObject;
        this.upgradeSprite = null;
        this.path = 0;
        this.numberOnPath = 1;
        levelManager = GameObject.Find("levelManager");
        Sprite abilityIcon = Resources.Load("rapidReels2", typeof(Sprite)) as Sprite;
        this.icon = abilityIcon;
    }

    public override void applyUpgrade()
    {
        levelManager.GetComponent<levelManager>().subtractMoney(this.cost);
        gameObject.GetComponent<Tower>().attackSpeed -= gameObject.GetComponent<Tower>().attackSpeed * .15f;
    }
    public override bool checkCost()
    {
        if(levelManager.GetComponent<levelManager>().money < this.cost)
            return false;
        else
            return true;
    }
    
}
