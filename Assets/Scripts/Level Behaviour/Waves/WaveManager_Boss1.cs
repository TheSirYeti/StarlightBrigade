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

    void Start()
    {
<<<<<<< Updated upstream
        foreach(GameObject dialogue in cutscenes){
            dialogue.SetActive(false);
        }
=======
        SoundManager.instance.StopAll();
        SoundManager.instance.Play(SoundID.MUSIC_LEVEL1_BOSS,true, 0.25f, 1f);
>>>>>>> Stashed changes
        player = GameObject.FindWithTag("Player");
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
                    inDialogue = true;
                    cutscenes[cutsceneManager].SetActive(true);
                    break;
                case 2:
                    GameObject boss = Instantiate(bossPrefab);
                    break;
                case 1:
                    inDialogue = true;
                    cutscenes[cutsceneManager].SetActive(true);
                    break;

            }
        } else if(cutscenes[cutsceneManager].GetComponent<Speech>().finished){
            inDialogue = false;
            cutsceneManager++;
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
