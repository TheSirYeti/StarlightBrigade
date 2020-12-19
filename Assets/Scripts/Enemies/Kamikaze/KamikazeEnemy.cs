using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeEnemy : MonoBehaviour
{

    public GameObject warning;
    public GameObject body;
    public float warningTime;
    public float spawnTime;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        warning.GetComponent<SpriteRenderer>().enabled = false;
        body.GetComponent<SpriteRenderer>().enabled = false;
        setPosition();
        spawnTime = warningTime;
    }

    // Update is called once per frame
    void Update()
    {
        checkWarning();
        spawnTime -= Time.deltaTime;
    }

    void setPosition(){
        float height = (float)Random.Range(0.5f, -4);
        body.transform.position = new Vector3(0, height, 0);
        warning.transform.position = new Vector3(0, height, 0);
        int position = Random.Range(1,5);
        switch(position){
            case 1:
                body.transform.position += new Vector3(-10,0,0);
                warning.transform.position += new Vector3(-8,0,0);
                break;
            case 2:
                body.transform.position += new Vector3(-10,0,0);
                warning.transform.position += new Vector3(-8,0,0);
                break;
            case 3:
                body.transform.position += new Vector3(10,0,0);
                warning.transform.position += new Vector3(8,0,0);
                body.transform.localScale += new Vector3(0, -2.5f, 0);
                speed = speed * -1;
                break;
            case 4:
                body.transform.position += new Vector3(10,0,0);
                warning.transform.position += new Vector3(8,0,0);
                body.transform.localScale += new Vector3(0, -2.5f, 0);
                speed = speed * -1;
                break;
        }

    }

    void checkWarning(){
        if(spawnTime <= Time.deltaTime){
            warning.GetComponent<SpriteRenderer>().enabled = false;
            body.GetComponent<SpriteRenderer>().enabled = true;
            body.GetComponent<shipMovement>().ready = true;
        } else {
            warning.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
