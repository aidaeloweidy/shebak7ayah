using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ESC_POS_USB_NET.Printer;
using UnityEngine.EventSystems;


public class TimeController : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 10f;
    public Text countdowntext;
    public bool GameOver = false;
    public GameObject GameOvertext;
    public PrintFun printObject;
    public ChangeScene scenes;
    public float waitTime = 10f;
    //Printer printer = new Printer("XP-80C (copy 2)");

    // System.Text.EncodingProvider ppp = System.Text.CodePagesEncodingProvider.Instance;
    // Encoding.RegisterProvider(ppp);

    //Bitmap image = new Bitmap(Bitmap.FromFile())

    bool Printed = false;


    void Start()
    {
        currentTime = startingTime;
        GameOvertext.SetActive(false);
    }

    void Update()
    {
        // if (Input.GetMouseButtonDown(0)) {
        currentTime -= 1 * Time.deltaTime;
        countdowntext.text = currentTime.ToString("0");
        //}

        if (currentTime <= 20)
        {
            countdowntext.color = Color.red;
        }
        if (currentTime <= 0)
        {
            currentTime = 0;
            //countdowntext.text = "ﺓﺮﻜﺑ ﻰﻟﺎﻌﺗ";
            countdowntext.fontSize = 30;
            GameOver = true;
        }

        if (GameOver && !Printed)
        {
            GameOvertext.SetActive(true);
            EventSystem.current.SetSelectedGameObject(GameOvertext.transform.GetChild(0).GetChild(0).gameObject);
            StartCoroutine(Loading());
            Printed = true;
            printObject.ToPrintLoss();

        }

       
    }

    // public void Restart()
    // {
    //     //string sceneName = SceneManager.GetActiveScene().name;
    //     SceneManager.LoadScene("Start", LoadSceneMode.Single);
    // }

    private IEnumerator Loading()
    {
        // pauses this method's execution until the waitTime has passed
        yield return new WaitForSeconds(waitTime);

        // once the wait time has passed, change the level
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
}
