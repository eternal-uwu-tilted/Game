using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEn : MonoBehaviour
{
    [SerializeField]
    public Transform shotpos;
    public Transform shotpos2;
    public GameObject BulletEn;
    float fireRate;
    float nextFire;
    void Start()
    {
        fireRate = 3f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheakifTimeToFire();

    }


    void CheakifTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(BulletEn, shotpos.transform.position, transform.rotation);
            Instantiate(BulletEn, shotpos2.transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
