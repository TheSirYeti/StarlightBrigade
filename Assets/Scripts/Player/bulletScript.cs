using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.up;

        if(transform.position.y >= 13)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag.Equals("Enemy")){
            col.gameObject.GetComponent<EnemyScript>().hp--;
            col.gameObject.GetComponent<EnemyScript>().damageTimer = Time.timeSinceLevelLoad + 1f;
            Destroy(gameObject);
            GameObject player = GameObject.FindWithTag("Player");
            if(player.GetComponent<Performance>().hp <100){
                player.GetComponent<Performance>().hp += 0.15f;
            }
        }

        if(col.gameObject.tag.Equals("Boss")){
            col.gameObject.GetComponent<BossScript>().hp--;
            col.gameObject.GetComponent<BossScript>().damageTimer = Time.timeSinceLevelLoad + 0.25f;
            Destroy(gameObject);
            GameObject player = GameObject.FindWithTag("Player");
            if(player.GetComponent<Performance>().hp <100){
                player.GetComponent<Performance>().hp += 0.5f;
            }
        }
        
    }
}
