﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Controls : MonoBehaviour
{

    public GameObject panel;
    
    public void delete(){
        Destroy(panel);
    }
}