﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorVisible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
<<<<<<< Updated upstream
        if(player.GetComponent<PlayerBehaviour>().deathFlag || player.GetComponent<PlayerBehaviour>().wonLevel){
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
=======
            if(player == null){
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            } else {
                if(player.GetComponent<PlayerBehaviour>().deathFlag || player.GetComponent<PlayerBehaviour>().wonLevel){
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
            }
>>>>>>> Stashed changes
    }
}
