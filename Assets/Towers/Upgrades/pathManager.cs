using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pathManager : MonoBehaviour
{
    public int[] upgradePaths;
    public int startedPaths;
    public bool[] pathEnabled;
    public Upgrade[][] selectedTowerUpgrades;
    public GameObject towersUI;
    public bool maxedPath = false;
    // Start is called before the first frame update
    void Start()
    {
        int numOfUpgradePaths = gameObject.GetComponent<Tower>().numOfUpgradePaths;
        upgradePaths = new int[numOfUpgradePaths];
        pathEnabled = new bool[numOfUpgradePaths];
        startedPaths = 0;
        // Enable all paths initially
        for(int i = 0;i< upgradePaths.Length; i++)
        {
            pathEnabled[i] = true;
        }
    }

    public void Update()
    {
        if(towersUI != null)
        {
            for(int i = 0;i< upgradePaths.Length; i++)
            {
                if(pathEnabled[i])
                {
                    if(selectedTowerUpgrades[i][upgradePaths[i]].cost > GameObject.Find("levelManager").GetComponent<levelManager>().money)
                    {
                        towersUI.GetComponent<TowerUI>().pathButtons[i].GetComponent<Image>().color = Color.black;
                        towersUI.GetComponent<TowerUI>().pathButtons[i].interactable = false;                       
                    }
                    else
                    {
                        if(pathEnabled[i])
                        {
                        towersUI.GetComponent<TowerUI>().pathButtons[i].GetComponent<Image>().color = Color.white;
                        towersUI.GetComponent<TowerUI>().pathButtons[i].interactable = true;   
                        }
                    } 
                }
            }
        }    
    }

    public void updatePaths(GameObject towerUI)
    {
        towersUI = towerUI;
        selectedTowerUpgrades = gameObject.GetComponent<Tower>().towerUpgrades;

        Image[][] pathImageArrays = {
        towerUI.GetComponent<TowerUI>().Path1Up,
        towerUI.GetComponent<TowerUI>().Path2Up,
        towerUI.GetComponent<TowerUI>().Path3Up,
        towerUI.GetComponent<TowerUI>().Path4Up
        };
        for(int i = 0;i< upgradePaths.Length; i++)
        {
           int pathIndex = i;
           if(maxedPath)
           {
            if(upgradePaths[i] == 5)
            {
                pathEnabled[i] = false;
            }
           }
           if(upgradePaths[i] != 6)
           {
           //Set names
           towerUI.GetComponent<TowerUI>().pathTitles[i].text = selectedTowerUpgrades[i][upgradePaths[i]].name;
           //Set costs
           towerUI.GetComponent<TowerUI>().pathCosts[i].text = selectedTowerUpgrades[i][upgradePaths[i]].cost.ToString();
           //Set descriptions
           towerUI.GetComponent<TowerUI>().abilityDesc[i].text = selectedTowerUpgrades[i][upgradePaths[i]].effectString;
           //Set icons
           //towerUI.GetComponent<TowerUI>().abilityIcons[i].sprite = selectedTowerUpgrades[i][upgradePaths[i]].icon;
           }
           else
           {
             pathEnabled[i] = false;
             towerUI.GetComponent<TowerUI>().pathButtons[i].interactable = false;
           }
           //Disable paths that should be disabled
           if(pathEnabled[i] == false)
           {
                towerUI.GetComponent<TowerUI>().pathButtons[i].GetComponent<Image>().color = Color.black;
                towerUI.GetComponent<TowerUI>().pathButtons[i].interactable = false;
           }
           for(int x = 0; x < upgradePaths[i]; x++)
           {
            pathImageArrays[i][x].GetComponent<Image>().color = Color.green;
           }
           //UPDATEICONS//towerUI.GetComponent<TowerUI>().
        }
    }
    public void addButtonListeners(GameObject towerUI)
    {
        for(int i = 0;i< upgradePaths.Length; i++)
        {
            int pathIndex = i;
            towerUI.GetComponent<TowerUI>().pathButtons[i].onClick.AddListener(() => UpgradePath(pathIndex));    
        }
    }
    public void UpgradePath(int pathIndex)
    {
        Debug.Log(pathIndex);
        if (upgradePaths[pathIndex] == 0)
        {
            bool canAfford = selectedTowerUpgrades[pathIndex][0].checkCost();
            if(canAfford)
            {
                gameObject.GetComponent<Tower>().towerWorth += selectedTowerUpgrades[pathIndex][0].cost;
                gameObject.GetComponent<Tower>().calculateSellAmount();
                startedPaths++;
                upgradePaths[pathIndex] = 1;
                checkForMaxPaths();
                selectedTowerUpgrades[pathIndex][0].applyUpgrade();
                updatePaths(towersUI);
                return;
            }
            else
            {
                return;
            }
        }
        if (upgradePaths[pathIndex] == 1)
        {
            bool canAfford = selectedTowerUpgrades[pathIndex][1].checkCost();
            if(canAfford)
            {
                gameObject.GetComponent<Tower>().towerWorth += selectedTowerUpgrades[pathIndex][1].cost;
                gameObject.GetComponent<Tower>().calculateSellAmount();
                upgradePaths[pathIndex] = 2;
                selectedTowerUpgrades[pathIndex][1].applyUpgrade();
                updatePaths(towersUI);
                return;
            }
            else
            {
                return;
            }
        }
        if (upgradePaths[pathIndex] == 2)
        {
            bool canAfford = selectedTowerUpgrades[pathIndex][2].checkCost();
            if(canAfford)
            {
                gameObject.GetComponent<Tower>().towerWorth += selectedTowerUpgrades[pathIndex][2].cost;
                gameObject.GetComponent<Tower>().calculateSellAmount();
                upgradePaths[pathIndex] = 3;
                selectedTowerUpgrades[pathIndex][2].applyUpgrade();
                updatePaths(towersUI);
                return;
            }
            else
            {
                return;
            }
        }
        if (upgradePaths[pathIndex] == 3)
        {
            bool canAfford = selectedTowerUpgrades[pathIndex][3].checkCost();
            if(canAfford)
            {
                gameObject.GetComponent<Tower>().towerWorth += selectedTowerUpgrades[pathIndex][3].cost;
                gameObject.GetComponent<Tower>().calculateSellAmount();
                upgradePaths[pathIndex] = 4;
                selectedTowerUpgrades[pathIndex][3].applyUpgrade();
                updatePaths(towersUI);
                return;
            }
            else
            {
                return;
            }
        }
        if (upgradePaths[pathIndex] == 4)
        {
            bool canAfford = selectedTowerUpgrades[pathIndex][4].checkCost();
            if(canAfford)
            {
                gameObject.GetComponent<Tower>().towerWorth += selectedTowerUpgrades[pathIndex][4].cost;
                gameObject.GetComponent<Tower>().calculateSellAmount();
                upgradePaths[pathIndex] = 5;
                selectedTowerUpgrades[pathIndex][4].applyUpgrade();
                if(maxedPath)
                {
                    pathEnabled[pathIndex] = false;
                }
                updatePaths(towersUI);
                return;
            }
            else
            {
                return;
            }
        }
        if (upgradePaths[pathIndex] == 5 && maxedPath == false)
        {
            bool canAfford = selectedTowerUpgrades[pathIndex][5].checkCost();
            if(canAfford)
            {
                gameObject.GetComponent<Tower>().towerWorth += selectedTowerUpgrades[pathIndex][5].cost;
                gameObject.GetComponent<Tower>().calculateSellAmount();
                upgradePaths[pathIndex] = 6;
                selectedTowerUpgrades[pathIndex][5].applyUpgrade();
                maxedPath = true;    
                pathEnabled[pathIndex] = false;
                
                updatePaths(towersUI);
                return;
            }
            else
            {
                return;
            }
        }
    }

    
    public void checkForMaxPaths()
    {
        if(startedPaths == 2)
        {
            for(int i = 0; i < upgradePaths.Length; i++)
            {
                if(upgradePaths[i] == 0)
                {
                    pathEnabled[i] = false;    
                }
            }
        }
    }
}
