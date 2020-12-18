using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowLifeUI : MonoBehaviour
{
    public Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0.1f);
    public bool soundFlag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkLowLife();
    }

    void checkLowLife(){
        GameObject player = GameObject.FindWithTag("Player");
        if(player.GetComponent<Performance>().hp < 33.3f && player.GetComponent<Performance>().hp > 0){
            Color tmp = GetComponent<Image>().color;
            tmp.a = 1f;
            GetComponent<Image>().color = tmp;
            if(!soundFlag){
                SoundManager.instance.Play(SoundID.LOW_HP, true, 1f, 1);
                soundFlag = !soundFlag;
            }
        } else {
            Color tmp = GetComponent<Image>().color;
            tmp.a = 0f;
            GetComponent<Image>().color = tmp;
            if(soundFlag){
                SoundManager.instance.Stop(SoundID.LOW_HP);
                soundFlag = !soundFlag;
            }
        }

        transform.localScale += scaleChange;
        if(transform.localScale.y <= 1 || transform.localScale.y >= 2){
            scaleChange = -scaleChange;
        }
    }
}
