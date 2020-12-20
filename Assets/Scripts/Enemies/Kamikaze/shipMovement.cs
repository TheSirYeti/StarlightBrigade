using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMovement : MonoBehaviour
{
    private float speed;
    public bool ready = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0; //transform.parent.GetComponent<KamikazeEnemy>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.right;
        if(transform.position.x <= -11 && transform.position.x >= 11){
            Destroy(gameObject);
        }
        if(ready){
            speed = transform.parent.GetComponent<KamikazeEnemy>().speed;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag.Equals("Player")){
            if(col.gameObject.GetComponent<PlayerBehaviour>().damageCooldownTimer <= Time.time){
                col.gameObject.GetComponent<Performance>().hp-=10;
                col.gameObject.GetComponent<PlayerBehaviour>().damageCooldownTimer = col.gameObject.GetComponent<PlayerBehaviour>().baseCooldown + Time.time;
            }
            Destroy(transform.parent);
            //Destroy(gameObject);
        }
    }
}

