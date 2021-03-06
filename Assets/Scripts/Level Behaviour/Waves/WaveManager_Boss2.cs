﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager_Boss2 : MonoBehaviour
{
    public int waveAmount;
    public GameObject bossPrefab1;
    public GameObject bossPrefab2;
    public GameObject bossPrefab3;
    public GameObject player;
    public string nextLevel;
    public bool inDialogue = false;
    public List<GameObject> cutscenes = new List<GameObject>();
    public int cutsceneManager = 0;
    private GameObject currentDialogue;
    private bool dialogueFlag;

    public GameObject kamikazePrefab;
    public float kamikazeTimer;
    private float kamikazeCount = 0;

    void Start()
    {
        SoundManager.instance.StopAll();
        SoundManager.instance.Play(SoundID.MUSIC_LEVEL2_BOSS,true, 0.35f, 1f);
        //foreach(GameObject dialogue in cutscenes){
        //    dialogue.SetActive(false);
        //}
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {   
        WavePlanner();
        spawnKamikaze();
    }

    void WavePlanner(){
        if(!EnemiesAlive() && !player.GetComponent<PlayerBehaviour>().amDead && !inDialogue){
            waveAmount--;
            switch(waveAmount){
                case 4:
                    currentDialogue = new GameObject();
                    currentDialogue = Instantiate(cutscenes[cutsceneManager], cutscenes[cutsceneManager].transform.position, cutscenes[cutsceneManager].transform.rotation);
                    currentDialogue.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                    inDialogue = true;
                    dialogueFlag = true;
                    break;
                case 3:
                    GameObject boss1 = Instantiate(bossPrefab1, new Vector3(-5, 10, 0), Quaternion.identity);
                    GameObject boss2 = Instantiate(bossPrefab2, new Vector3(5, 10, 0), Quaternion.identity);
                    break;
                case 2:
                    currentDialogue = new GameObject();
                    currentDialogue = Instantiate(cutscenes[cutsceneManager], cutscenes[cutsceneManager].transform.position, cutscenes[cutsceneManager].transform.rotation);
                    currentDialogue.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                    inDialogue = true;
                    dialogueFlag = true;
                    break;
                case 1:
                    GameObject boss3 = Instantiate(bossPrefab3, new Vector3(-0.5f, 10, 0), Quaternion.identity);
                    break;
                case 0:
                    currentDialogue = new GameObject();
                    currentDialogue = Instantiate(cutscenes[cutsceneManager], cutscenes[cutsceneManager].transform.position, cutscenes[cutsceneManager].transform.rotation);
                    currentDialogue.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                    inDialogue = true;
                    dialogueFlag = true;
                    break;
                case -1:
                    GameObject fade = GameObject.FindWithTag("FadeManager");
                    fade.GetComponent<FadeManager>().startTransition(nextLevel);
                    break;
                
            }
        } else if(currentDialogue.GetComponent<Speech>().finished && dialogueFlag){
            dialogueFlag = false;
            inDialogue = false;
            cutsceneManager++;
            kamikazeCount = kamikazeTimer + Time.timeSinceLevelLoad;
        }
    }

    void spawnKamikaze(){
        if(!inDialogue){
            print(kamikazeCount);
            print(Time.timeSinceLevelLoad);
            if(kamikazeCount <= Time.timeSinceLevelLoad){
                print("entra");
                GameObject kamikaze = Instantiate(kamikazePrefab);
                kamikazeCount += kamikazeTimer;
            }
        }
    }




    private bool EnemiesAlive(){
        bool flag = false;
        if(GameObject.FindWithTag("Boss")) {
            flag = true;
        }
        return flag;
    }
}
