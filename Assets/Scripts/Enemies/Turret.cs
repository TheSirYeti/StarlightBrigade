using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform target;
    private Rigidbody2D rb;

    public GameObject bulletPrefab;
    public float speed;
    public float rotateSpeed;

    private float nextShot;
    public float fireRate;

    public Transform firePoint1; public Transform firePoint2;
    // Start is called before the first frame update
    void Start()
    {
        nextShot = Random.Range(3, 10);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if(!player.GetComponent<PlayerBehaviour>().deathFlag && this.transform.parent.GetComponent<BossScript>().diedTimer == -1){
            Vector2 targetPos = (Vector2)target.position;
            Vector2 direction = targetPos - (Vector2)transform.position;
            direction.Normalize();
            transform.up = direction * -1;

            if(nextShot < Time.timeSinceLevelLoad){
                GameObject bullet1 = Instantiate(bulletPrefab, firePoint1.position, Quaternion.identity);
                bullet1.GetComponent<Rigidbody2D>().AddForce(direction * speed);
                GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, Quaternion.identity);
                bullet2.GetComponent<Rigidbody2D>().AddForce(direction * speed);
                nextShot = Time.timeSinceLevelLoad + fireRate + Random.Range(3, 6);;
            }
        }
    }
}

