using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createplatform : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platform_prefab;
    public GameObject platform_prefab2;
    float timer;
    GameObject p;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        timer += Time.deltaTime;
        if (timer >= 1.5f)
        {
            timer = 0;
            int r = Random.Range(0, 2);
            if (r == 0)
            {
                 p = Instantiate(platform_prefab);
            }
            else if (r == 1)
            {
                 p = Instantiate(platform_prefab2);
            }
            p.transform.position = new Vector2(Random.Range(-5f, 5f), 15);
            //p.transform.localScale = new Vector2(Random.Range(3, 5), 0.5f);
            p.GetComponent<platformmove>().speed = 3;


        }

       
        
    }

}
