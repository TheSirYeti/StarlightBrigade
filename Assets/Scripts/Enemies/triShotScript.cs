using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triShotScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    void Start()
    {
        pos1.transform.rotation = Quaternion.identity;
        pos2.transform.rotation = Quaternion.identity;
        pos3.transform.rotation = Quaternion.identity;
        GameObject bullet1 = Instantiate(bulletPrefab, pos1.transform.position, pos1.transform.localRotation);
        GameObject bullet2 = Instantiate(bulletPrefab, pos2.transform.position, pos2.transform.localRotation);
        GameObject bullet3 = Instantiate(bulletPrefab, pos3.transform.position, pos3.transform.localRotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
