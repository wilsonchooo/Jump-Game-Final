using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformvertical : MonoBehaviour
{
    // Start is called before the first frame update
    public float distance;
    float starty;
    float yLoc;
    bool up;
    Vector2 pos;


    void Start()
    {
        up = true;
        starty = transform.position.y;
        yLoc = transform.position.y;
        //distance = distance + transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            yLoc += Time.deltaTime;
            if (yLoc > starty + distance)
            {
                up = false;
            }
        }
        else
        {
            yLoc -= Time.deltaTime;

            if (yLoc < distance * -1 + starty)
            {
                up = true;
            }
        }
        pos.y = yLoc;
        pos.x = transform.position.x;
        transform.position = pos;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            GameObject emptyObject = new GameObject();
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

    }
}

