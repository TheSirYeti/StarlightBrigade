using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speech : MonoBehaviour
{
    public Text textBox;
    public List<string> sentences = new List<string>();
    private int index;
    public float typingSpeed;
    public string name;
    public Text nameText;
    public Animator animator;
    public Image[] images;
    public bool skip = false;
    private bool isTyping;
    public List<int> imagePerSentence = new List<int>();

    void Start(){
        StartCoroutine(TypeSentence());
        nameText.text = name;
    }

    void Update(){
        if(Input.GetKeyDown("space")){
            if(!skip){
                textBox.text = "";
                int counter = 0;
                foreach(char letter in sentences[index].ToCharArray()){
                    if(counter >= 69){
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
        print(index);
        int counter = 0;
        foreach(char letter in sentences[index].ToCharArray()){
            if(!skip){
                if(counter >= 69){
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
            index++;
            textBox.text = "";
            skip = false;
            StartCoroutine(TypeSentence());
        } else {
            textBox.text = "";
            animator.SetTrigger("noMoreDialogue");
        }
    }
}
