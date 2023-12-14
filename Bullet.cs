using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float bulletSpeed;
    
    Rigidbody2D rb;

    public int damage = 2;

    void Start()
    {
  
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * bulletSpeed ;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<enemyPatrol>(out enemyPatrol enemyComponent))
        {
            enemyComponent.TakeDamage(damage);
        }
        

        AudioManager.instance.PlaySFX("BulletHit");

        Destroy(gameObject);
    }

}
