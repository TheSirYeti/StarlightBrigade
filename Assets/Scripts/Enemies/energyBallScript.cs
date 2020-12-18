using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyBallScript : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Update()
    {
        transform.position -= speed * Time.deltaTime * Vector3.up;
        if(transform.position.y <= -7){
            Destroy(gameObject);
        }

        transform.localScale += new Vector3(0.5f,0.5f,0.5f) * Mathf.Sin(Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag.Equals("Player")){
            if(col.gameObject.GetComponent<PlayerBehaviour>().damageCooldownTimer <= Time.time){
                col.gameObject.GetComponent<Performance>().hp-=10;
                col.gameObject.GetComponent<PlayerBehaviour>().damageCooldownTimer = col.gameObject.GetComponent<PlayerBehaviour>().baseCooldown + Time.time;
            }
            Destroy(gameObject); 
        }
    }
}
