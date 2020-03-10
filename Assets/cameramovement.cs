using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;


    Vector2 cameraDim;
    Vector2 worldDim;


    void Start()
    {
        cameraDim = new Vector2(Screen.width, Screen.height);
        worldDim = Camera.main.ScreenToWorldPoint(new Vector2(cameraDim.x, cameraDim.y));
    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.y >= 25)
        {

            transform.position = new Vector3(0, 30, -10);
        }

        else if (player.transform.position.y >= 15)
        {

            transform.position = new Vector3(0, 20, -10);
        }
        else if (player.transform.position.y >= 5)
        {

            //transform.position.y = transform.position.y;
            transform.position = new Vector3(0,  10, -10);
            //transform.position.Set(transform.position.x, 10f,0);
        }

        else if (player.transform.position.y <= worldDim.y)
        {
            transform.position = new Vector3(0, 0, -10);
        }


    }
}
