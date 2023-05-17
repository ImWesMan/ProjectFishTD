using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    public int cost;
    public string name;
    public string effectString;
    public GameObject parent;
    public Sprite upgradeSprite;
    public int path;
    public int numberOnPath;
    public abstract void applyUpgrade();
    public abstract bool checkCost();
}
