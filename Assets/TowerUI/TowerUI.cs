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
    public Button[] pathButtons;
    public TMP_Text[] pathCosts;
    public TMP_Text[] pathTitles;
    public Image[] Path1Up;
    public Image[] Path2Up;
    public Image[] Path3Up;
    public Image[] Path4Up;
    public TMP_Text[] abilityDesc;
    public Image[] abilityIcons;
    public void callTargetModeRight()
    {
        Tower.selectedTower.GetComponent<Tower>().targetModeRight();
    }
    public void callTargetModeLeft()
    {
         Tower.selectedTower.GetComponent<Tower>().targetModeLeft();
    }
}

