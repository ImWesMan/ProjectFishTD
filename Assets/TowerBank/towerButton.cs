using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class towerButton : MonoBehaviour
{
    public GameObject linkedTower;
    public int cost;
    public int costText;
    public GameObject levelManager;
    private GameObject towerPreview;
     private bool isDragging;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("levelManager");
        cost = linkedTower.GetComponent<Tower>().towerCost;
        costText = cost;
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
    
            // If the user clicks, place the real tower
            if (Input.GetMouseButtonDown(0))
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
        towerPreview = Instantiate(linkedTower, new Vector3(999, 999, 0), Quaternion.identity);
        towerPreview.GetComponent<Tower>().enabled = false;
        isDragging = true;
    }
}
