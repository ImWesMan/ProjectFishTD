using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor
{
    public class mover : MonoBehaviour
{
    public float speed = 0.1f;
    bool checker = true;
    private SpriteRenderer sr;
    public float range = 1f; 
       

    private float startPoint;

    // Start is called before the first frame update
    void Start()
    {
        range = Random.Range(0.2f, 1f);
        sr = GetComponent<SpriteRenderer>();
       startPoint = sr.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        print(transform.position.x);

        if (checker)
        {
            moveLeft();
        }
        if (!checker)
        {
            moveRight();
        }
        if (sr.transform.position.x >= startPoint+ range)
        {
            
            checker = false;
            sr.flipX = true;
        }
        if (sr.transform.position.x <= startPoint - range)
        {
            checker = true;
            sr.flipX = false;
        }
    }

    void moveLeft()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void moveRight()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
}