using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
//using ESC_POS_USB_NET.Printer;

public class ChangeScene : MonoBehaviour
{

    public GameObject ScreentoShow;
    public string ScenetoGo;
    public PrintFun printObject;

    public float waitTime = 6f;
   // Printer printer = new Printer("XP-80C (copy 2)");
    public void Start()
    {
        ScreentoShow.SetActive(false);
    }
    public void ShowLevelTwo()
    {
        ScreentoShow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(ScreentoShow.transform.GetChild(1).gameObject);
        StartCoroutine(Loading());
    }

    public void PrintWin() {
        printObject.ToPrintWin();
    }

    public void Win(){
        StartCoroutine(RestartGame());
    }

    private IEnumerator Loading()
    {
        // pauses this method's execution until the waitTime has passed
        yield return new WaitForSeconds(waitTime);

        // once the wait time has passed, change the level
        SceneManager.LoadScene(ScenetoGo, LoadSceneMode.Single);

    }

    private IEnumerator RestartGame()
    {
        // pauses this method's execution until the waitTime has passed
        yield return new WaitForSeconds(waitTime);

        // once the wait time has passed, change the level
        SceneManager.LoadScene("Start", LoadSceneMode.Single);

    }
}


