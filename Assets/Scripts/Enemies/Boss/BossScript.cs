using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int yGoal;
    public GameObject bulletPrefab;
    public GameObject missilePrefab;
    public GameObject turret;

    public float nextShot;
    public float fireRate;

    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    public Transform spawnPoint5;
    public Transform spawnPoint6;

    public Animator animator;

    public float hp;

    private float timer;

    public float damageTimer;
    public float diedTimer = -1;
    
    public float maxHP;
    public bool lowHPbuff;

    void Start(){
        nextShot = 0f;
        maxHP = hp;
        transform.GetSiblingIndex();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if(!player.GetComponent<PlayerBehaviour>().deathFlag && diedTimer == -1){
            if(nextShot < Time.timeSinceLevelLoad){
                fire();
                nextShot = Time.timeSinceLevelLoad + fireRate;
            }
            checkDamaged();
        }
        checkIfDead();
        Movement();

        if(hp <= (maxHP * 0.25f) && !lowHPbuff){
            lowHPbuff = !lowHPbuff;
            fireRate = fireRate / 2f;
        }
    }

    void checkDamaged(){
        if(damageTimer > Time.timeSinceLevelLoad){
            this.GetComponent<SpriteRenderer>().color = new Color(1f,0.5f,0.5f,1);
            this.transform.GetChild(6).GetComponent<SpriteRenderer>().color = new Color(1f,0.5f,0.5f,1);
            this.transform.GetChild(7).GetComponent<SpriteRenderer>().color = new Color(1f,0.5f,0.5f,1);
            this.transform.GetChild(8).GetComponent<SpriteRenderer>().color = new Color(1f,0.5f,0.5f,1);
            this.transform.GetChild(9).GetComponent<SpriteRenderer>().color = new Color(1f,0.5f,0.5f,1);
            this.transform.GetChild(10).GetComponent<SpriteRenderer>().color = new Color(1f,0.5f,0.5f,1);
            this.transform.GetChild(11).GetComponent<SpriteRenderer>().color = new Color(1f,0.5f,0.5f,1);
            //animator.SetBool("isDamaged", true);
        } else {
            this.transform.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);//animator.SetBool("isDamaged", false);
            this.transform.GetChild(6).GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
            this.transform.GetChild(7).GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
            this.transform.GetChild(8).GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
            this.transform.GetChild(9).GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
            this.transform.GetChild(10).GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
            this.transform.GetChild(11).GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        }
    }

    void checkIfDead(){
        if(hp <= 0 && diedTimer == -1){
            diedTimer = Time.timeSinceLevelLoad + 3f;
            GetComponent<Collider2D>().enabled = false;
            SoundManager.instance.Play(SoundID.EXPLOSION, false, 0.1f, 1f);
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<Performance>().hp = 99999;
            foreach (GameObject enemyBullet in GameObject.FindGameObjectsWithTag("EnemyBullet")){
                Destroy(enemyBullet);
            }
        }
        if(diedTimer <= Time.timeSinceLevelLoad && diedTimer != -1){
            Destroy(gameObject);
            print("llega? 3");
        } else if(diedTimer != -1){
            animator.SetBool("dead", true);
        }
    }

    void Movement(){
        if(transform.position.y > yGoal){
            transform.position -= 1 * Time.deltaTime * Vector3.up;
        }
        transform.position += (Vector3.right * 2) * Mathf.Sin(timer * 2) * Time.deltaTime;
        timer += Time.deltaTime;
    }

    void fire(){
        if(yGoal >= transform.position.y){
            int position = Random.Range(1,7);
            GameObject bullet;
            switch(position){
                case 1:
                    bullet = Instantiate(bulletPrefab, spawnPoint1.position, Quaternion.identity);
                    break;
                case 2:
                    bullet = Instantiate(bulletPrefab, spawnPoint2.position, Quaternion.identity);
                    break;
                case 3:
                    bullet = Instantiate(bulletPrefab, spawnPoint3.position, Quaternion.identity);
                    break;
                case 4:
                    bullet = Instantiate(bulletPrefab, spawnPoint4.position, Quaternion.identity);
                    break;
                case 5:
                    bullet = Instantiate(bulletPrefab, spawnPoint5.position, Quaternion.identity);
                    break;
                case 6:
                    bullet = Instantiate(bulletPrefab, spawnPoint6.position, Quaternion.identity);
                    break;
            }
            int position2 = Random.Range(1,7);
            while(position2 == position){
                position2 = Random.Range(1,7);
            }
            GameObject bullet2;
            switch(position2){
                case 1:
                    bullet2 = Instantiate(missilePrefab, spawnPoint1.position, Quaternion.identity);
                    break;
                case 2:
                    bullet2 = Instantiate(missilePrefab, spawnPoint2.position, Quaternion.identity);
                    break;
                case 3:
                    bullet2 = Instantiate(missilePrefab, spawnPoint3.position, Quaternion.identity);
                    break;
                case 4:
                    bullet2 = Instantiate(missilePrefab, spawnPoint4.position, Quaternion.identity);
                    break;
                case 5:
                    bullet2 = Instantiate(missilePrefab, spawnPoint5.position, Quaternion.identity);
                    break;
                case 6:
                    bullet2 = Instantiate(missilePrefab, spawnPoint6.position, Quaternion.identity);
                    break;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag.Equals("PlayerBullet")){
            hp--;
            Destroy(col.gameObject);
        }
    }
}
