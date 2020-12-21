using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int enemyType;
    public float fireRate;
    private float nextShot;

    public GameObject bulletPrefab;

    public int yGoal; 
    private float timer;
    private float randomVariable;

    public int hp = 999;

    public Transform spawnPosition;

    public Animator animator;

    public float damageTimer;
    public float diedTimer = -1;

    public string soundCode;

    void Start()
    {
        nextShot = Time.timeSinceLevelLoad + Random.Range(3,500) / 10f;
        randomVariable = Random.Range(500, 600) / 100f;
        SelectEnemyType();
    }

    void Update()
    {
        MovementAndFire();
        checkIfDead();
        checkDamaged();
    }

    void fire(){
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition.position, Quaternion.identity);
        switch(enemyType){
            case 1:
                SoundManager.instance.Play(SoundID.ENEMY_SHOT,false, 0.5f, 1f);
                break;
            case 2:
                SoundManager.instance.Play(SoundID.ENEMY_ENERGY,false, 0.5f, 1f);
                break;
            case 3:
                SoundManager.instance.Play(SoundID.ENEMY_MISSILE,false, 0.5f, 1f);
                break;
        }
    }

    public int getType(){
        return enemyType;
    }

    void checkDamaged(){
<<<<<<< Updated upstream
        if(damageTimer > Time.time && diedTimer == -1){
=======
        Color color;
        if(damageTimer > Time.timeSinceLevelLoad && diedTimer == -1){
>>>>>>> Stashed changes
            //animator.SetBool("isDamaged", true);
            this.GetComponent<SpriteRenderer>().color = new Color(1,0.25f,0.25f,1);
        } else this.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);//animator.SetBool("isDamaged", false);
    }

    void checkIfDead(){
        if(hp <= 0 && diedTimer == -1){
            diedTimer = Time.timeSinceLevelLoad + 1.5f;
            GetComponent<Collider2D>().enabled = false;
        }

        if(diedTimer < Time.timeSinceLevelLoad && diedTimer != -1){
            Destroy(gameObject);
        } else if(diedTimer != -1){
            animator.SetBool("dead", true);
        }
    }

    void MovementAndFire(){
        if(transform.position.y <= yGoal){
            if(nextShot <= Time.timeSinceLevelLoad){
                fire();
                nextShot += Time.timeSinceLevelLoad + (Random.Range(50,fireRate*10) / 10f);
            }
        }

        if(transform.position.y > yGoal){
            transform.position -= 4 * Time.deltaTime * Vector3.up;
        }

        transform.position += (Vector3.right /  randomVariable) * Mathf.Sin(timer * randomVariable) * Time.deltaTime;
        timer += Time.deltaTime;
    }

    void SelectEnemyType(){
            switch(enemyType){
                case 1:
                    hp = 1; //4
                    fireRate = 15;
                    break;
                case 2:
                    hp = 1; //6
                    fireRate = 20;
                    break;
                case 3:
                    hp = 1; //6
                    fireRate = 15;
                    break;
            }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag.Equals("PlayerBullet")){
            damageTimer = Time.timeSinceLevelLoad + 1f;
            hp--;
            Destroy(col.gameObject);
        }
        else if(col.gameObject.tag.Equals("EnemyBullet")){
            if(col.gameObject.GetComponent<DirectedMissile>() != null && col.gameObject.GetComponent<DirectedMissile>().preStartTime < Time.timeSinceLevelLoad){
                hp--;
                damageTimer = Time.timeSinceLevelLoad + 1f;
                Destroy(col.gameObject);
            }
        }
    }
}
