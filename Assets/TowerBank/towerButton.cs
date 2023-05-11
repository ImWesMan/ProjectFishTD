using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
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
                levelManager.GetComponent<levelManager>().subtractMoney(cost);
                GameObject newTower = Instantiate(linkedTower, towerPreview.transform.position, Quaternion.identity);
                Destroy(towerPreview);
                isPressed = false;
                inPreviewMode = false;
            }
            if (Input.GetMouseButtonDown(0) && insideCollider && isPressed)
            {
                Destroy(towerPreview);
                isPressed = false;
                inPreviewMode = false;
            }
            if (Input.GetMouseButtonUp(0) && !insideCollider && isDragging)
            {
                levelManager.GetComponent<levelManager>().subtractMoney(cost);
                GameObject newTower = Instantiate(linkedTower, towerPreview.transform.position, Quaternion.identity);
                Destroy(towerPreview);
                isDragging = false;
                inPreviewMode = false;
            }
            if (Input.GetMouseButtonUp(0) && insideCollider && isDragging)
            {
                Destroy(towerPreview);
                isDragging = false;
                inPreviewMode = false;
            }
        }
    }

    public void onPress()
    {
        if(levelManager.GetComponent<levelManager>().money < cost)
        {
            return;
        }
        if(inPreviewMode)
        {
            Destroy(towerPreview);
            isPressed = false;
            inPreviewMode = false;
        }
        else
        {
        inPreviewMode = true;
        towerPreview = Instantiate(linkedTower, new Vector3(999, 999, 0), Quaternion.identity);
        towerPreview.GetComponent<Tower>().enabled = false;
        Debug.Log("Is pressed = true");
        isPressed = true;
        }
    }

     public void onDrag()
    {
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
        towerPreview.GetComponent<Tower>().enabled = false;
        Debug.Log("Is dragging = true");
        isDragging = true;
        }
    }
}
