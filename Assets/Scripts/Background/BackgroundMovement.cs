using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    public float speed;
    public float nextYpos;
    // Start is called before the first frame update
    void Start()
    {
        //-26.487
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    public void moveNext(){
        nextYpos = transform.position.y - 7.14f;
    }

    void move(){
        if(nextYpos <= transform.position.y){
            transform.position -= Vector3.up * speed * Time.deltaTime;
        }
    }
}
