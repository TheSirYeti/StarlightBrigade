using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DirectedMissile : MonoBehaviour
{

    public Transform target;
    private Rigidbody2D rb;
    public float chaseTime;
    public float speed;
    public float rotateSpeed;
    public float preStartTime;
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(0, 2);
        preStartTime = Time.timeSinceLevelLoad + 3f;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        chaseTime = Time.timeSinceLevelLoad + 3f;
        lifetime = Time.timeSinceLevelLoad + lifetime;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if(chaseTime >= Time.timeSinceLevelLoad){
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, (transform.up * -1)).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = (transform.up * -1) * speed * Time.deltaTime;
        } else {
            rb.angularVelocity = 0;
            rb.velocity = (transform.up * -1.5f) * speed * Time.deltaTime;
            GetComponent<SpriteRenderer>().material.color = new Color(1,0,0);
        }

        if(lifetime < Time.timeSinceLevelLoad){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(preStartTime < Time.timeSinceLevelLoad){
            if(col.gameObject.tag.Equals("Player")){
                if(col.gameObject.GetComponent<PlayerBehaviour>().damageCooldownTimer <= Time.time){
                    col.gameObject.GetComponent<Performance>().hp-=10;
                    col.gameObject.GetComponent<PlayerBehaviour>().damageCooldownTimer = col.gameObject.GetComponent<PlayerBehaviour>().baseCooldown + Time.time;
                }
            }
            Destroy(gameObject);
        }
        
    }
}

