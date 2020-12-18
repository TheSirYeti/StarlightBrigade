using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public GameObject player;
    public GameObject bonusUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Performance>().hp >= 66.6f){
            bonusUI.SetActive(true);
        } else bonusUI.SetActive(false);
    }
}
