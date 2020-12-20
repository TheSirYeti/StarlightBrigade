using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficultyBehaviour : MonoBehaviour
{
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
