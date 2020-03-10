
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    Rigidbody2D rb;
    public float force;
    public float speed;
    public Slider s;
    public Slider h;
    public GameObject position;
    public Text t;
    

    public Button exit;
    public Button restart;
    public Text end;

    bool paused;
    float timer;
    int uses = 3;
    float forceh;
    float timerVal;
    bool facingleft;
    bool floor;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        position.SetActive(false);

        restart.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        end.gameObject.SetActive(false);
        timer = 0;
        paused = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        floor = true;
        if(collision.gameObject.name == "end")
        {
            Debug.Log(timer);
            timer += Time.deltaTime;
            if(timer>2)
            {
                restart.gameObject.SetActive(true);
                exit.gameObject.SetActive(true);
                end.gameObject.SetActive(true);
                Time.timeScale = 0;
            }

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        floor = false;
        timer = 0;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                Time.timeScale = 0;
                exit.gameObject.SetActive(true);
                restart.gameObject.SetActive(true);
                paused = false;
            }

            else if (!paused)
            {
                Time.timeScale = 1;
                exit.gameObject.SetActive(false);
                restart.gameObject.SetActive(false);
                paused = true;
            }

        }
        Vector2 vel = rb.velocity;

        if (Input.GetKey(KeyCode.Z))
        {
            if (forceh < 5 && forceh > -5)
                forceh -= Time.deltaTime * 3;
            else
                forceh = -4.9f; 

            facingleft = true;
        }
        if (Input.GetKey(KeyCode.X))
        {
            if (forceh < 5 && forceh > -5)
                forceh += Time.deltaTime * 3;
            else
                forceh = 4.9f;

            facingleft = false;
        }


        h.value = forceh;
        if (Input.GetKey(KeyCode.Space))
        {
            //rb.AddForce(transform.up * force, ForceMode2D.Impulse);
            timerVal += Time.deltaTime*2;
            s.value = timerVal;
            
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (uses > 0 &&floor)
            {
                position.SetActive(true);
                position.transform.position = this.transform.position;
            }
            else if(uses<0)
                position.SetActive(false);

            if(floor)
            {
                Vector3 v = new Vector3(.5f, 0, .5f);
                rb.AddForce(Vector2.up * force * s.value, ForceMode2D.Impulse);

                vel = new Vector2(speed * forceh, vel.y);
                rb.AddForce(vel * force * s.value * 5);

            }
            timerVal = 0;
            s.value = timerVal;
            forceh = 0;
            h.value = forceh;


        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (position.activeSelf == true)
            {
                uses--;

                if (uses >= 0)
                {
                    transform.position = position.transform.position;
                    position.SetActive(false);
                    t.text = "Reverse Uses: " + uses;
                }
                else t.text = "No reverse uses remaining";
            }
        }




        }
}
