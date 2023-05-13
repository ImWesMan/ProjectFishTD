using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setRangeIndicatorSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(transform.parent.GetComponent<Tower>().attackRange * 4 + 1, transform.parent.GetComponent<Tower>().attackRange * 4 + 1, 1);
    }
}
