using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public int damage = 1;
    public float speed;


    void Update()
    {
        transform.Translate(Vector2.down * speed);
        if (health <= 0)
        {
            
            Destroy(gameObject);
            Score.scores += 100; 
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().health -= damage;
            Destroy(gameObject);
        }
        if (other.CompareTag("Bullet"))
        {
            health -= 5;
        }
        if (other.CompareTag("Alo"))
        {
            EnemyCount.enemys -= 1;
            health -= 20;
        }
    }


}
