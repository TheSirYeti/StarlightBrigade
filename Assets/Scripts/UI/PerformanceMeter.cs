using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceMeter : MonoBehaviour
{

    public GameObject player;
    private float countHP;

    // Start is called before the first frame update
    void Start()
    {
        countHP = player.GetComponent<Performance>().hp;
        transform.Rotate(0,0, player.GetComponent<Performance>().hp * -1.8f);
    }

    // Update is called once per frame
    void Update()
    {
        if(countHP != player.GetComponent<Performance>().hp && player.GetComponent<Performance>().hp <= 100){
            countHP = countHP - player.GetComponent<Performance>().hp;
            transform.Rotate(0,0, countHP * 1.8f);
            countHP = player.GetComponent<Performance>().hp;
        }
    }
}
