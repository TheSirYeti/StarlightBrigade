using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public Animator animator;

	private string levelToLoad;
	
    public void startTransition(string Level){
        animator.SetTrigger("fadeOut");
        levelToLoad = Level;
    }

	public void OnFadeComplete (){
		SceneManager.LoadScene(levelToLoad);
	}
}
