using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public string nextLevel;
    public bool inDialogue = false;
    public List<GameObject> cutscenes = new List<GameObject>();
    public int cutsceneManager = 0;
    private GameObject currentDialogue;
    private bool dialogueFlag;
    public int cutsceneStage;
    public bool skip = false;
    public bool isTyping;
    public bool finished = false;
    public Text textBox;
    public List<string> sentences = new List<string>();
    private int index;
    public float typingSpeed;
    public int maxChar;
    public List<Image> images = new List<Image>();
    public List<int> imageToShow = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = "";
        images[imageToShow[index]].enabled = true;
        StartCoroutine(TypeSentence());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("return")){
            if(!skip){
                textBox.text = "";
                int counter = 0;
                foreach(char letter in sentences[index].ToCharArray()){
                    if(counter >= maxChar  && letter == ' '){
                        textBox.text += "\n";
                        counter = 0;
                    }
                    textBox.text += letter;
                    counter++;
                    skip = true;
                    isTyping = false;
                }
            } else if(isTyping == false){
                NextSentence();
            }
        }
    }

    IEnumerator TypeSentence(){
        isTyping = true;
        int counter = 0;
        foreach(char letter in sentences[index].ToCharArray()){
            if(!skip){
                if(counter >= maxChar && letter == ' '){
                    textBox.text += "\n";
                    counter = 0;
                }
                textBox.text += letter;
                counter++;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        isTyping = false;
        skip = true;
    }
    public void NextSentence(){
        if(index < sentences.Count - 1){
            images[imageToShow[index]].enabled = false;
            index++;
            images[imageToShow[index]].enabled = true;
            textBox.text = "";
            skip = false;
            StartCoroutine(TypeSentence());
        } else {
            GameObject fade = GameObject.FindWithTag("FadeManager");
            fade.GetComponent<FadeManager>().startTransition(nextLevel);
        }
    }
}
