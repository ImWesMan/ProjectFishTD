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
    private bool isDragging;
    private bool inPreviewMode;
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
        if(levelManager.GetComponent<levelManager>().money < cost)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }

        if (isDragging)
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
        if (Input.GetMouseButtonDown(0) && !insideCollider)
        {
            levelManager.GetComponent<levelManager>().subtractMoney(cost);
            GameObject newTower = Instantiate(linkedTower, towerPreview.transform.position, Quaternion.identity);
            Destroy(towerPreview);
            isDragging = false;
        }
    }
    }

    public void onPress()
    {
        if(isDragging)
        {
            Destroy(towerPreview);
            isDragging = false;
        }
        else
        {
        towerPreview = Instantiate(linkedTower, new Vector3(999, 999, 0), Quaternion.identity);
        towerPreview.GetComponent<Tower>().enabled = false;
        isDragging = true;
        }
    }
}
