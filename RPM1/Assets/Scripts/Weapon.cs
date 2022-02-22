using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shotpos;
    public Transform shotpos2;
    public GameObject Bullet;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, shotpos.transform.position, transform.rotation);
            Instantiate(Bullet, shotpos2.transform.position, transform.rotation);
        }
    }
}
