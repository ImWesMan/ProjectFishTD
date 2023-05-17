using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public abstract class Tower : MonoBehaviour
{
    public float attackDamage;
    public float attackRange;
    public float attackSpeed;
    private float attackTimer;
    public bool rotates;
    public bool animated;
    [SerializeField]
    public GameObject[] targets;
    public string[] targetModes = { "First", "Last", "Strong" };
    public string targetMode;
    public int targetModeIndex;
    public GameObject levelManager;
    public int towerCost;
    public bool isColliding = true;
    public int kills = 0;
    public static Tower selectedTower;
    public GameObject towerUIPrefab;
    public GameObject towerUI;
    public GameObject rangeIndicator;
    public string towerName;
    public int sellAmount;
    public bool attacks;
    public int numOfUpgradePaths;
    public Upgrade[][] towerUpgrades;

    public abstract void Attack(GameObject fish);
    public abstract void assignUpgrades();
    //See tower ranges for debug purposes
    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        isColliding = true;
    }

     void OnTriggerStay2D(Collider2D col)
    {
        isColliding = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
       isColliding = false;
    }

    public void Start()
    {
        this.sellAmount = Mathf.RoundToInt(towerCost * 0.70f);
        levelManager = GameObject.Find("levelManager");
        towerUI = Instantiate(towerUIPrefab, GameObject.Find("Canvas").transform);
        towerUI.GetComponent<TowerUI>().towerNameText.text = towerName;
        towerUI.GetComponent<TowerUI>().sellButton.onClick.AddListener(sellTower);
        towerUI.GetComponent<TowerUI>().exitButton.onClick.AddListener(hideTowerUI);
        towerUI.SetActive(false);
        attackTimer = attackSpeed;
        isColliding = true;
        if(attacks)
        {
            targetMode = targetModes[0];
            targetModeIndex = 0;
            towerUI.GetComponent<TowerUI>().targetMode.SetActive(true); 
        }
        else
        {
            targetMode = null;
            towerUI.GetComponent<TowerUI>().targetMode.SetActive(false); 
        }
        gameObject.GetComponent<pathManager>().addButtonListeners(towerUI);
    }

    public void sellTower()
    {
        levelManager.GetComponent<levelManager>().addMoney(sellAmount);
        Destroy(towerUI);
        Destroy(gameObject);
    }

    public void OnMouseDown()
    {
        if (selectedTower != null && selectedTower != this )
        {
            selectedTower.GetComponent<Tower>().hideTowerUI();
        }
        if (selectedTower == this)
        {
            selectedTower = null;
            hideTowerUI();
        }
        else
        {
            selectedTower = this;
            displayTowerUI();
        }
    }

    public void displayTowerUI()
    {
        towerUI.SetActive(true);
        rangeIndicator.transform.localScale = new Vector3(attackRange * 4 + 1, attackRange * 4 + 1, 1);
        rangeIndicator.SetActive(true);
        gameObject.GetComponent<pathManager>().updatePaths(towerUI);
    }

    public void hideTowerUI()
    {
        selectedTower = null;
        rangeIndicator.SetActive(false);
        towerUI.SetActive(false);
    }

    public void targetModeLeft()
    {
        if(targetModeIndex == 0)
        {
            return;
        }
        else
        {
            targetModeIndex-=1;
            targetMode = targetModes[targetModeIndex];
        }
    }
    public void targetModeRight()
    {
        if(targetModeIndex == targetModes.Length - 1)
        {
            return;
        }
        else
        {
            targetModeIndex+=1;
            targetMode = targetModes[targetModeIndex];
        }
    }

    public void Update()
    {
        if(selectedTower)
        {
            towerUI.GetComponent<TowerUI>().popCount.text = kills.ToString();
            towerUI.GetComponent<TowerUI>().towerSprite.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            towerUI.GetComponent<TowerUI>().targetModeText.text = targetMode;
            towerUI.GetComponent<TowerUI>().sellText.text = "SELL +" + sellAmount.ToString();
        } 
        targets = GameObject.FindGameObjectsWithTag("Fish");
        sortTargets();
        // Check for fish in attack range and attack if timer is up
        if (attackTimer >= attackSpeed)
        {
            checkCloseToTag("Fish");
        }
        else
        {
            // Update the attack timer
            attackTimer += Time.deltaTime;
        }
    }

    protected void checkCloseToTag(string tag)
    {
         // Attack the first target in range
        foreach(GameObject target in targets) {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if(distance <= attackRange)
            {
                Attack(target);
                attackTimer = 0.0f; // Reset the attack timer
                break; // Only attack one target per frame
            }
        }
    }
    protected void DamageFish(GameObject fish, float damage)
    {
        if(rotates)
        {
        Vector3 targetDirection = fish.transform.position - transform.position; // Calculate the direction to the target
        Vector3 forwardDirection = transform.forward;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg; // Calculate the angle between the tower and the target
        angle += 90;
        transform.rotation = Quaternion.Euler(0, 0, angle); // Set the tower's rotation to face the target
        }
        if(animated)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Attack");
        }
        fish.GetComponent<Fish>().life -= damage;
        if(fish.GetComponent<Fish>().life <= 0)
        {
            kills++;
            fish.GetComponent<Fish>().deathSound.Play();
            levelManager.GetComponent<levelManager>().addMoney(fish);
            Debug.Log("A fish died");
            Destroy(fish);
        }
    }

    public void sortTargets()
    {
         // Sort the targets by currentPercentage and distance to the next waypoint
        if(targetMode == "First")
        {
        System.Array.Sort(targets, (x, y) =>
        {
            float distanceToNextWaypointX = Vector3.Distance(x.transform.position, x.GetComponent<FishMovement>().GetNextPosition());
            float distanceToNextWaypointY = Vector3.Distance(y.transform.position, y.GetComponent<FishMovement>().GetNextPosition());

            float currentPercentageX = x.GetComponent<Fish>().GetCurrentPercentage();
            float currentPercentageY = y.GetComponent<Fish>().GetCurrentPercentage();

            int comparison = currentPercentageY.CompareTo(currentPercentageX);
            if (comparison != 0)
            {
                return comparison;
            }
            else
            {
                return distanceToNextWaypointX.CompareTo(distanceToNextWaypointY);
            }
        });
        }
        else if(targetMode == "Last")
        {
        System.Array.Sort(targets, (x, y) =>
        {
            float distanceToNextWaypointX = Vector3.Distance(x.transform.position, x.GetComponent<FishMovement>().GetNextPosition());
            float distanceToNextWaypointY = Vector3.Distance(y.transform.position, y.GetComponent<FishMovement>().GetNextPosition());

            float currentPercentageX = x.GetComponent<Fish>().GetCurrentPercentage();
            float currentPercentageY = y.GetComponent<Fish>().GetCurrentPercentage();

            int comparison = currentPercentageX.CompareTo(currentPercentageY);
            if (comparison != 0)
            {
                return comparison;
            }
            else
            {
                return distanceToNextWaypointY.CompareTo(distanceToNextWaypointX);
            }
        });
        }
        else if (targetMode == "Strong")
        {
        System.Array.Sort(targets, (x, y) =>
        {
            float distanceToNextWaypointX = Vector3.Distance(x.transform.position, x.GetComponent<FishMovement>().GetNextPosition());
            float distanceToNextWaypointY = Vector3.Distance(y.transform.position, y.GetComponent<FishMovement>().GetNextPosition());

            float currentHPX = x.GetComponent<Fish>().life;
            float currentHPY = y.GetComponent<Fish>().life;

            int comparison = currentHPY.CompareTo(currentHPX);
            if (comparison != 0)
            {
                return comparison;
            }
            else
            {
                float currentPercentageX = x.GetComponent<Fish>().GetCurrentPercentage();
                float currentPercentageY = y.GetComponent<Fish>().GetCurrentPercentage();

                int percentageComparison = currentPercentageY.CompareTo(currentPercentageX);
                if (percentageComparison != 0)
                {
                    return percentageComparison;
                }
                else
                {
                    return distanceToNextWaypointX.CompareTo(distanceToNextWaypointY);
                }
            }
            });
        }   
    }
}
