using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmovehorizontal : MonoBehaviour
{
    public float distance;
    float startx;
    float xLoc;
    bool up;
    Vector2 pos;
    GameObject emptyObject;
    void Start()
    {
        up = true;
        startx = transform.position.x;
        xLoc = transform.position.x;
        //distance = distance + transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            xLoc += Time.deltaTime;
            if (xLoc > startx + distance)
            {
                up = false;
            }
        }
        else
        {
            xLoc -= Time.deltaTime;

            if (xLoc < distance * -1 + startx)
            {
                up = true;
            }
        }
        pos.y = transform.position.y;
        pos.x = xLoc;
        transform.position = pos;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            emptyObject = new GameObject();
            emptyObject.transform.SetParent(transform);
            collision.collider.transform.SetParent(emptyObject.transform);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.name == "player")
        {
            collision.collider.transform.SetParent(null);
        }
        Destroy(emptyObject);
    }
}
