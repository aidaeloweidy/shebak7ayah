using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   
    public void RestartButton() {
       // string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
}
