using UnityEngine;
using UnityEngine.EventSystems;

public class DisableOptionsOnClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject optionsUI;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(optionsUI.GetComponent<RectTransform>(), Input.mousePosition))
        {
            optionsUI.SetActive(false);
        }
    }
}