using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Performance : MonoBehaviour
{

    public float hp = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfDead();
        if(GetComponent<PlayerBehaviour>().wonLevel){
            hp = 999;
        }
    }

    void CheckIfDead(){
        if(hp <= 0){
            GetComponent<PlayerBehaviour>().amDead = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag.Equals("EnemyBullet")){
            if(this.gameObject.GetComponent<PlayerBehaviour>().damageCooldownTimer <= Time.time){
                this.gameObject.GetComponent<Performance>().hp-=10;
                this.gameObject.GetComponent<PlayerBehaviour>().damageCooldownTimer = this.gameObject.GetComponent<PlayerBehaviour>().baseCooldown + Time.time;
            }
            Destroy(col.gameObject);
        }
    }
}
