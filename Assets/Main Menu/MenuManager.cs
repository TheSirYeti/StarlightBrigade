using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject controlsWindow;
    public GameObject creditsWindow;

    void Start(){
        SoundManager.instance.StopAll();
        SoundManager.instance.Play(SoundID.MAINMENU,true, 0.35f, 1f);
        controlsWindow.SetActive(false);
        creditsWindow.SetActive(false);
    }
    public void openControls(){
        controlsWindow.SetActive(true);
        creditsWindow.SetActive(false);
    }

    public void closeControls(){
        controlsWindow.SetActive(false);
    }

    public void openCredits(){
        creditsWindow.SetActive(true);
        controlsWindow.SetActive(false);
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
    
}
