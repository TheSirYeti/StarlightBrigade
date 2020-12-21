using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.StopAll();
        SoundManager.instance.Play(SoundID.INTRO_SB,false, 0.3f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
