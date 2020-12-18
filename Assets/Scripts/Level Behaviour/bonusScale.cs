using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusScale : MonoBehaviour
{
    public Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0.1f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale += scaleChange;
        if(transform.localScale.y <= 1 || transform.localScale.y >= 2){
            scaleChange = -scaleChange;
        }
    }
}
