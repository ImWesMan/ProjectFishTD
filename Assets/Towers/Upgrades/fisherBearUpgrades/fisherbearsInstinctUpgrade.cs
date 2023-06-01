using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fisherbearsInstinctUpgrade : Upgrade
{
    GameObject levelManager;
    // Start is called before the first frame update
    void Start()
    {
        this.cost = 800;
        this.name = "Fisherbear's Instinct";
        this.effectString = "Allows Fisherbear to detect and attack hidden fish";
        this.parent = gameObject;
        this.upgradeSprite = null;
        this.path = 1;
        this.numberOnPath = 2;
        levelManager = GameObject.Find("levelManager");
        Sprite abilityIcon = Resources.Load("rapidReels2", typeof(Sprite)) as Sprite;
        this.icon = abilityIcon;
    }

    public override void applyUpgrade()
    {
        levelManager.GetComponent<levelManager>().subtractMoney(this.cost);
        gameObject.GetComponent<Tower>().hitsHidden = true;
    }
    public override bool checkCost()
    {
        if(levelManager.GetComponent<levelManager>().money < this.cost)
            return false;
        else
            return true;
    }
    
}
