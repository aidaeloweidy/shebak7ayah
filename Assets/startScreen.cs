using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class startScreen : MonoBehaviour
{
    public GameObject introScreen;
   // public GameObject instructions;
    public Button button;

    public float waitTime = 6f;
    // Start is called before the first frame update
    void Start()
    {
        introScreen.SetActive(false);
        //instructions.SetActive(false);
        EventSystem.current.SetSelectedGameObject(button.gameObject);

    }

    public void GetNext() {
        if (Input.GetKeyDown(KeyCode.Return)) {

          
            //button.onClick.Invoke();
            introScreen.SetActive(true);
            StartCoroutine(Loading());
        }

        
            
    }
private IEnumerator Loading()
{
    // pauses this method's execution until the waitTime has passed
    yield return new WaitForSeconds(waitTime);

        // once the wait time has passed, change the level
        SceneManager.LoadScene("Level-One", LoadSceneMode.Single);
}
}

