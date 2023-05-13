using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class detectClick : MonoBehaviour
{
   void OnMouseDown()
   {
    if(Tower.selectedTower != null && !EventSystem.current.IsPointerOverGameObject())
    {
        Tower.selectedTower.GetComponent<Tower>().hideTowerUI();
    }
   }
}
