using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager_Boss1 : MonoBehaviour
{
    public int waveAmount;
    public int[] spawnPositions = new int[17];
    private int lineAmount;
    private List<int> enemyAmount = new List<int>();
    public GameObject bossPrefab;
    public GameObject player;
    public string nextLevel;
    public bool inDialogue = false;
    public List<GameObject> cutscenes = new List<GameObject>();
    private int cutsceneManager = 0;
    private GameObject currentDialogue;
    private bool dialogueFlag;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        SoundManager.instance.Play(SoundID.MUSIC_LEVEL1,true, 0.25f, 1f);
        initializePositionArray();
    }

    // Update is called once per frame
    void Update()
    {   
        WavePlanner();
    }

    void initializePositionArray(){
        int xValue = -8;
        for(int i = 0; i < spawnPositions.Length; i++){
            spawnPositions[i] = xValue;
            xValue++;
        }
    }

    void WavePlanner(){
        if(!BossAlive() && !player.GetComponent<PlayerBehaviour>().amDead && !inDialogue){
            print(BossAlive());
            print(player.GetComponent<PlayerBehaviour>().amDead);
            print(inDialogue);
            waveAmount--;
            enemyAmount.Clear();
            switch(waveAmount){
                case 3:
                    currentDialogue = new GameObject();
                    currentDialogue = Instantiate(cutscenes[cutsceneManager], cutscenes[cutsceneManager].transform.position, cutscenes[cutsceneManager].transform.rotation);
                    currentDialogue.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                    inDialogue = true;
                    dialogueFlag = true;
                    break;
                case 2:
                    GameObject boss = Instantiate(bossPrefab, new Vector3(-0.5f, 10, 0), Quaternion.identity);
                    break;
                case 1:
                    inDialogue = true;
                    cutscenes[cutsceneManager].SetActive(true);
                    break;

            }
        } else {
                if(currentDialogue.GetComponent<Speech>().finished && dialogueFlag){
                print("fin");
                dialogueFlag = false;
                inDialogue = false;
                cutsceneManager++;
                }
        }
    }

    private bool BossAlive(){
        bool flag = false;
        if(GameObject.FindWithTag("Boss") != null) {
            flag = true;
        }
        return flag;
    }
}
