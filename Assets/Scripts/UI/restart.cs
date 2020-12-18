using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public void restartLevel(){
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }

    public void loadMenu(){
        SoundManager.instance.Stop(SoundID.MUSIC_LEVEL1);
        SceneManager.LoadScene("MainMenu");
    }
}
