using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int waveAmount;
    public int[] spawnPositions = new int[17];
    private int lineAmount;
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    private List<int> enemyAmount = new List<int>();
    public GameObject bossPrefab;
    public GameObject background;
    public GameObject player;
    public string nextLevel;
    public bool inDialogue = false;
    public GameObject dialogueManager;
    // Start is called before the first frame update



    void Start()
    {
        player = GameObject.FindWithTag("Player");
        waveAmount = 7;
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
        if(!EnemiesAlive() && !player.GetComponent<PlayerBehaviour>().amDead && !inDialogue){
            waveAmount--;
            enemyAmount.Clear();
            switch(waveAmount){
                case 6:
                    background.GetComponent<BackgroundMovement>().moveNext();
                    enemyAmount.Add(2);
                    generateLevel();
                    break;
                case 5:
                    background.GetComponent<BackgroundMovement>().moveNext();
                    enemyAmount.Add(2);
                    enemyAmount.Add(1);
                    generateLevel();
                    break;
                case 4:
                    background.GetComponent<BackgroundMovement>().moveNext();
                    enemyAmount.Add(2);
                    enemyAmount.Add(2);
                    generateLevel();
                    break;
                case 3:
                    background.GetComponent<BackgroundMovement>().moveNext();
                    enemyAmount.Add(2);
                    enemyAmount.Add(1);
                    enemyAmount.Add(1);
                    generateLevel();
                    break;
                case 2:
                    background.GetComponent<BackgroundMovement>().moveNext();
                    enemyAmount.Add(1);
                    enemyAmount.Add(2);
                    enemyAmount.Add(2);
                    generateLevel();
                    break;
                case 1:
                    background.GetComponent<BackgroundMovement>().moveNext();
                    GameObject fade = GameObject.FindWithTag("FadeManager");
                    fade.GetComponent<FadeManager>().startTransition(nextLevel);
                    break;
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
