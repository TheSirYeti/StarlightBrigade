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
    public List<string> names = new List<string>();
    public Text nameText;
    public Animator animator;
    public Image[] images;
    public bool skip = false;
    public bool isTyping;
    public List<int> imagePerSentence = new List<int>();
    public bool finished = false;


    void Start(){
        StartCoroutine(TypeSentence());
        string test = "";
        foreach(int i in imagePerSentence){
            test += i + " ";
        }
    }

    void Update(){
        if(Input.GetKeyDown("return")){
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
        int counter = 0;
        setAvatar(imagePerSentence[index]);
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
            finished = true;
            textBox.text = "";
            animator.SetTrigger("noMoreDialogue");
        }
    }

    void setAvatar(int image){
        for(int i = 0; i < images.Length; i++){
            images[i].enabled = false;
        }
        images[image].enabled = true;
        nameText.text = names[image];
    }
}
