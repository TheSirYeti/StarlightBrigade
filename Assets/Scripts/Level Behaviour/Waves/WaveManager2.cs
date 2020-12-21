using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager2 : MonoBehaviour
{
    public int waveAmount;
    public int[] spawnPositions = new int[17];
    private int lineAmount;
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    private List<int> enemyAmount = new List<int>();
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
        initializePositionArray();
        foreach(GameObject enemy in enemyPrefabs){
            enemy.GetComponent<EnemyScript>().fireRate = enemy.GetComponent<EnemyScript>().fireRate / 1.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        WavePlanner();
        spawnKamikaze();
    }

    void initializePositionArray(){
        int xValue = -8;
        for(int i = 0; i < spawnPositions.Length; i++){
            spawnPositions[i] = xValue;
            xValue++;
        }
    }

    void WavePlanner(){
        if(!EnemiesAlive() && !player.GetComponent<PlayerBehaviour>().amDead && !inDialogue){
            waveAmount--;
            enemyAmount.Clear();
            switch(waveAmount){
                case 7:
                    inDialogue = true;
                    currentDialogue = new GameObject();
                    currentDialogue = Instantiate(cutscenes[cutsceneManager], cutscenes[cutsceneManager].transform.position, cutscenes[cutsceneManager].transform.rotation);
                    currentDialogue.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                    dialogueFlag = true;
                    //cutscenes[cutsceneManager].SetActive(true);
                    break;
                case 6:
                    enemyAmount.Add(1);
                    enemyAmount.Add(1);
                    generateLevel();
                    break;
                case 5:
                    enemyAmount.Add(1);
                    enemyAmount.Add(2);
                    generateLevel();
                    kamikazeTimer--;
                    break;
                case 4:
                    enemyAmount.Add(0);
                    enemyAmount.Add(2);
                    enemyAmount.Add(1);
                    kamikazeTimer--;
                    generateLevel();
                    break;
                case 3:
                    enemyAmount.Add(0);
                    enemyAmount.Add(3);
                    enemyAmount.Add(1);
                    kamikazeTimer--;
                    generateLevel();
                    break;
                case 2:
                    enemyAmount.Add(0);
                    enemyAmount.Add(4);
                    enemyAmount.Add(2);
                    generateLevel();
                    break;
                case 1:
                    currentDialogue = new GameObject();
                    currentDialogue = Instantiate(cutscenes[cutsceneManager], cutscenes[cutsceneManager].transform.position, cutscenes[cutsceneManager].transform.rotation);
                    currentDialogue.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                    inDialogue = true;
                    dialogueFlag = true;
                    break;
                case 0:
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
    void generateLevel(){
        int yLevel = 4;
        int startYLevel = 10;
        for(int i = 0; i < enemyAmount.Count; i++){
            for(int j = 0; j < enemyAmount[i]; j++){
                fillLane(i, yLevel, startYLevel);
                yLevel--;
                startYLevel++;
            }
        }
    }

    void fillLane(int type, int yLevel, int startYLevel){
        for(int i = 0; i < spawnPositions.Length; i++){
            GameObject enemy = Instantiate(enemyPrefabs[type]);
            enemy.transform.position = new Vector3(spawnPositions[i], startYLevel, 0);
            enemy.GetComponent<EnemyScript>().yGoal = yLevel;
        }
    }

    private bool EnemiesAlive(){
        bool flag = false;
        if(GameObject.FindWithTag("Enemy") != null || GameObject.FindWithTag("Boss") != null && waveAmount != 1) {
            flag = true;
        }
        return flag;
    }
}
