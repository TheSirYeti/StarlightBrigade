using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject bulletPrefab;
    public static PlayerBehaviour player;
    public Animator animator;

    public bool wonLevel;

    public bool amDead = false;
    private float fireRate;
    public float baseFire;
    public float nextShot;

    public Transform spawnPosition1, spawnPosition2, spawnPosition3, spawnPosition4, spawnPosition5;
    public int power;
    public bool deathFlag = false;
    public float deathTime;
    public GameObject restartPanel;
    public GameObject winPanel;
    public GameObject specialPanel;
    public GameObject maxPanel;
    private GameObject bullet1, bullet2, bullet3, bullet4, bullet5; 


    public float damageCooldownTimer;
    public float baseCooldown;
    public bool specialReady = false;

    // Start is called before the first frame update
    void Start()
    {
        player = this;
        power = 1;
        winPanel.SetActive(false);
        restartPanel.SetActive(false);
        print("false");
        specialPanel.SetActive(false);
        maxPanel.SetActive(false);
        fireRate = baseFire;
    }

    // Update is called once per frame
    void Update()
    {
        if(!amDead){
            Movement();
            FireCheck();
            checkPerformance();
            damageCooldown();
        } else 
        {
            die();
        }
        win();

        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    void Movement(){
        if(!wonLevel){
            float h = speed * Input.GetAxis("Horizontal");
            float v = speed * Input.GetAxis("Vertical");
            switch(h){
                case float n when n > 0:
                    animator.SetBool("movingRight", true);
                    animator.SetBool("movingLeft", false);
                    break;
                case float n when n < 0:
                    animator.SetBool("movingLeft", true);
                    animator.SetBool("movingRight", false);
                    break;
                case 0:
                    animator.SetBool("movingLeft", false);
                    animator.SetBool("movingRight", false);
                    break;
            }
            transform.position += new Vector3(h * speed * Time.deltaTime, v * speed * Time.deltaTime, 0);
        }
        else { transform.position += Vector3.up * speed * Time.deltaTime; }
    }

    void FireCheck(){
        if(Input.GetKey(KeyCode.Space)){
            if(nextShot < Time.timeSinceLevelLoad){
                switch(power){
                    case 1:
                        bullet1 = Instantiate(bulletPrefab, spawnPosition1.position, Quaternion.identity);
                        SoundManager.instance.Play(SoundID.PLAYER_GUN,false, 0.1f, 1f);
                        break;
                    case 2:
                        bullet1 = Instantiate(bulletPrefab, spawnPosition2.position, Quaternion.identity);
                        bullet2 = Instantiate(bulletPrefab, spawnPosition3.position, Quaternion.identity);
                        SoundManager.instance.Play(SoundID.PLAYER_GUN,false, 0.1f, 1f);
                        break;
                    case 3:
                        bullet1 = Instantiate(bulletPrefab, spawnPosition1.position, Quaternion.identity);
                        bullet2 = Instantiate(bulletPrefab, spawnPosition2.position, Quaternion.identity);
                        bullet3 = Instantiate(bulletPrefab, spawnPosition3.position, Quaternion.identity);
                        SoundManager.instance.Play(SoundID.PLAYER_GUN,false, 0.1f, 1f);
                        break;
                    case 4:
                        bullet1 = Instantiate(bulletPrefab, spawnPosition2.position, Quaternion.identity);
                        bullet2 = Instantiate(bulletPrefab, spawnPosition3.position, Quaternion.identity);
                        bullet3 = Instantiate(bulletPrefab, spawnPosition4.position, Quaternion.identity);
                        bullet4 = Instantiate(bulletPrefab, spawnPosition5.position, Quaternion.identity);
                        SoundManager.instance.Play(SoundID.PLAYER_GUN,false, 0.1f, 1f);
                        break;
                    case 5:
                        bullet1 = Instantiate(bulletPrefab, spawnPosition2.position, Quaternion.identity);
                        bullet2 = Instantiate(bulletPrefab, spawnPosition3.position, Quaternion.identity);
                        bullet3 = Instantiate(bulletPrefab, spawnPosition4.position, Quaternion.identity);
                        bullet4 = Instantiate(bulletPrefab, spawnPosition5.position, Quaternion.identity);
                        bullet5 = Instantiate(bulletPrefab, spawnPosition1.position, Quaternion.identity);
                        SoundManager.instance.Play(SoundID.PLAYER_GUN,false, 0.1f, 1f);
                        break;
                }
                nextShot = Time.timeSinceLevelLoad + fireRate;
            }
        }
    }

    void checkPerformance(){
        if(player.GetComponent<Performance>().hp >= 66.6f){
            fireRate = baseFire / 2;
            specialReady = true;
            if(power < 5)
                specialPanel.SetActive(true);
            else maxPanel.SetActive(true);
        } else { fireRate = baseFire; specialReady = false; specialPanel.SetActive(false); maxPanel.SetActive(false); }

        if(Input.GetKeyDown(KeyCode.LeftShift) && player.GetComponent<Performance>().hp >= 66.6f && power < 5){
            power++;
            player.GetComponent<Performance>().hp = 50;
        }
    }

    void die(){
        if(!deathFlag){
            animator.SetBool("dead", true);
            deathTime = 2f + Time.timeSinceLevelLoad;
            deathFlag = !deathFlag;
        } else {
            if(deathTime < Time.timeSinceLevelLoad){
                restartPanel.SetActive(true);
            }
        }
    }

    void win(){
        if(wonLevel && transform.position.y >= 11){
            winPanel.SetActive(true);
        }
    }

    public void damageCooldown(){
        if(damageCooldownTimer >= Time.timeSinceLevelLoad){
            this.GetComponent<SpriteRenderer>().color = new Color(1,0.5f,0.5f,1);
        } else this.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
    }
}
