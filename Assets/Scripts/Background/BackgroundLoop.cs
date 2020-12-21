using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float edgepos;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.timeSinceLevelLoad * speed, edgepos);
        transform.position = startPos + Vector3.down * newPos;
    }
}
