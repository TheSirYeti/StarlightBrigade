using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    public Slider slider;
    public GameObject boss;
    void Start(){
        GameObject boss = GameObject.FindWithTag("Boss");
        slider.maxValue = boss.GetComponent<BossScript>().hp;
        slider.value = slider.maxValue;
    }

    void Update(){
        slider.value = boss.GetComponent<BossScript>().hp;

        if(slider.value <= 0){
            Destroy(gameObject);
        }
    }
}
