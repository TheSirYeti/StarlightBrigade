using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject controlsWindow;
    public GameObject creditsWindow;
    public GameObject quickPlayWindow;

    void Start(){
        controlsWindow.SetActive(false);
        creditsWindow.SetActive(false);
        quickPlayWindow.SetActive(false);
    }
    public void openControls(){
        controlsWindow.SetActive(true);
        creditsWindow.SetActive(false);
        quickPlayWindow.SetActive(false);
    }

    public void closeControls(){
        controlsWindow.SetActive(false);
    }

    public void openCredits(){
        creditsWindow.SetActive(true);
        controlsWindow.SetActive(false);
        quickPlayWindow.SetActive(false);
    }

    public void closeCredits(){
        creditsWindow.SetActive(false);
    }

    public void loadLevel(){
        SceneManager.LoadScene("Level1");
    }

    public void quitGame(){
        Application.Quit();
    }

    public void openQuickplay(){
        quickPlayWindow.SetActive(true);
        controlsWindow.SetActive(false);
        creditsWindow.SetActive(false);
    }

    public void closeQuickplay(){
        quickPlayWindow.SetActive(false);
    }
    
}
