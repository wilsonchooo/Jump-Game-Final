using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttons : MonoBehaviour
{
    public Text text;
    public Text fastest;
    float fast;
    float timer;
    private void Start()
    {
        timer = 0;
        fast = 0;
    }
    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
        timer = 0;
        Time.timeScale = 1;
    }

    public void exit()
    {
        Application.Quit();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        text.text = timer.ToString();

    }
}
