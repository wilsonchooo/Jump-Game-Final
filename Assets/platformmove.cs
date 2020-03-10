using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmove : MonoBehaviour
{
    public float speed;
    float starty;
    // Start is called before the first frame update
    void Start()
    {
        starty = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y > 25)
        {
            Destroy(this.gameObject);
        }
    }
}
