using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    public Transform PointA, PointB;
    private Transform curPoint;
    private Rigidbody2D rb;
    public GameObject EnemyWall;
    public float speed;
    public float health;
    public float maxhealth;
    public int damage = 4;
    public bool enemyDeath = false;



    void Start()
    {
        health = maxhealth;
        rb = GetComponent<Rigidbody2D>();
        curPoint = PointB.transform;
    }

    void Update()
    {


        Vector2 point = curPoint.position - transform.position;
        if (curPoint == PointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);

        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, curPoint.position) < 0.7f && curPoint == PointB)
        {
            curPoint = PointA.transform;
        }
        if (Vector2.Distance(transform.position, curPoint.position) < 0.7f && curPoint == PointA)
        {
            curPoint = PointB.transform;
        }

        if (enemyDeath == true)
        {
            Debug.Log("DESTROY THE FUCKING WALL");
            Destroy(EnemyWall);
        }

    }

    public void RemoveWall()
    {
        if (enemyDeath)
        {
            EnemyWall.SetActive(false);
        }
    }


    public void TakeDamage(int damage)
    {
       
        health -= damage;

        if (health <= 0)
        {

            Destroy(gameObject);
            AudioManager.instance.PlaySFX("PlayerDeath");
            enemyDeath = true;
            Debug.Log("Enemy Death " + enemyDeath);
            RemoveWall();
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            player.TakeDamage(damage);
        }
    }

}
