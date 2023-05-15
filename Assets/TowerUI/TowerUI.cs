using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TowerUI : MonoBehaviour
{
    public TMP_Text popCount;
    public Image towerSprite;
    public TMP_Text targetModeText;
    public TMP_Text towerNameText;
    public Button sellButton;
    public TMP_Text sellText;
    public Button exitButton;
    public GameObject targetMode;
    public Button leftSwitch;
    public Button rightSwitch; 

    public void callTargetModeRight()
    {
        Tower.selectedTower.GetComponent<Tower>().targetModeRight();
    }
    public void callTargetModeLeft()
    {
         Tower.selectedTower.GetComponent<Tower>().targetModeLeft();
    }
}

