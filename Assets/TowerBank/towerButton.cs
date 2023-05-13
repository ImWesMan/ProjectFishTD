using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class towerButton : MonoBehaviour
{
    public GameObject linkedTower;
    public int cost;
    public TMP_Text costText;
    public GameObject levelManager;
    private GameObject towerPreview;
    public bool isDragging;
    public bool isPressed;
    public bool inPreviewMode;
    public bool leftTheBank = false;
    public bool towerPlaced = false;
    public GameObject clickCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("levelManager");
        cost = linkedTower.GetComponent<Tower>().towerCost;
        costText.text = cost.ToString();
        isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(levelManager.GetComponent<levelManager>().money < cost || inPreviewMode)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        if(((towerPreview == null && !Input.GetMouseButton(0)) || (Input.GetMouseButtonUp(0) && towerPlaced)) && levelManager.GetComponent<levelManager>().money >= cost)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }

        if (EventSystem.current.IsPointerOverGameObject() && inPreviewMode)
        {
            towerPreview.SetActive(false);
        }
        if (!EventSystem.current.IsPointerOverGameObject() && inPreviewMode)
        {
              towerPreview.SetActive(true);
             leftTheBank = true;
        }

        if(leftTheBank && EventSystem.current.IsPointerOverGameObject() && inPreviewMode)
        {
            Debug.Log("Tower preview destroyed, Reason: left and re-entered bank");
            Destroy(towerPreview);
            isPressed = false;
            isDragging = false;
            inPreviewMode = false;
            leftTheBank = false;
            clickCollider.SetActive(true);
            return;
        }

        if (isPressed || isDragging)
        {
            // Move the tower preview along with the mouse
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            towerPreview.transform.position = mousePosition;

            bool insideCollider = towerPreview.GetComponent<Tower>().isColliding;
            
            // Change the color of the tower preview based on if it's inside of a collider or not
            if (!insideCollider)
            {
                towerPreview.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
            {
                towerPreview.GetComponent<SpriteRenderer>().color = Color.red;
            }

            // If the user clicks, place the real tower
            if (Input.GetMouseButtonDown(0) && !insideCollider && isPressed)
            {
                Debug.Log("Tower preview destroyed, Reason: placed");
                levelManager.GetComponent<levelManager>().subtractMoney(cost);
                GameObject newTower = Instantiate(linkedTower, towerPreview.transform.position, Quaternion.identity);
                Destroy(towerPreview);
                isPressed = false;
                inPreviewMode = false;
                leftTheBank = false;
                towerPlaced= true;
                clickCollider.SetActive(true);
            }
            if (Input.GetMouseButtonDown(0) && insideCollider && isPressed)
            {
                Debug.Log("Tower preview destroyed, Reason: placed in collider");
                Destroy(towerPreview);
                isPressed = false;
                inPreviewMode = false;
                leftTheBank = false;
                clickCollider.SetActive(true);
            }
            if (Input.GetMouseButtonUp(0) && !insideCollider && isDragging)
            {
                Debug.Log("Tower preview destroyed, Reason: placed");
                levelManager.GetComponent<levelManager>().subtractMoney(cost);
                GameObject newTower = Instantiate(linkedTower, towerPreview.transform.position, Quaternion.identity);
                Destroy(towerPreview);
                isDragging = false;
                inPreviewMode = false;
                leftTheBank= false;
                towerPlaced = true;
                clickCollider.SetActive(true);
            }
            if (Input.GetMouseButtonUp(0) && insideCollider && isDragging)
            {
                Debug.Log("Tower preview destroyed, Reason: let go in collider");
                Destroy(towerPreview);
                isDragging = false;
                inPreviewMode = false;
                leftTheBank = false;
                clickCollider.SetActive(true);
            }
        }
    }

    public void onPress()
    {
        if(Tower.selectedTower != null)
        {
        Tower.selectedTower.GetComponent<Tower>().hideTowerUI();
        }
        clickCollider.SetActive(false);
        towerPlaced= false;
        if(levelManager.GetComponent<levelManager>().money < cost)
        {
            Debug.Log("Not enough money");
            return;
        }
        if(inPreviewMode)
        {
            Debug.Log("pressed button while in preview mode");
            Destroy(towerPreview);
            isPressed = false;
            inPreviewMode = false;
        }
        else
        {
        Debug.Log("Preview made");
        inPreviewMode = true;
        towerPreview = Instantiate(linkedTower, new Vector3(999, 999, 0), Quaternion.identity);
        towerPreview.GetComponent<Tower>().rangeIndicator.SetActive(true);
        towerPreview.GetComponent<Tower>().enabled = false;
        Debug.Log("Is pressed = true");
        isPressed = true;
        }
    }

     public void onDrag()
    {
        if(Tower.selectedTower != null)
        {
        Tower.selectedTower.GetComponent<Tower>().hideTowerUI();
        }
        clickCollider.SetActive(false);
        towerPlaced= false;
        if(levelManager.GetComponent<levelManager>().money < cost)
        {
            return;
        }
        if(inPreviewMode)
        {
            Destroy(towerPreview);
            isDragging = false;
            inPreviewMode = false;
        }
        else
        {
        inPreviewMode = true;
        towerPreview = Instantiate(linkedTower, new Vector3(999, 999, 0), Quaternion.identity);
        towerPreview.GetComponent<Tower>().rangeIndicator.SetActive(true);
        towerPreview.GetComponent<Tower>().enabled = false;
        Debug.Log("Is dragging = true");
        isDragging = true;
        }
    }
}
