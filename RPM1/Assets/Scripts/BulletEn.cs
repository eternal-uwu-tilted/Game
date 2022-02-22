using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEn : MonoBehaviour
{
    public float speed;
    public int damage = 1;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().health -= damage;
            Destroy(gameObject);
        }
        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
