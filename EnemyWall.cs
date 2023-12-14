using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWall : MonoBehaviour
{
    private enemyPatrol EnemyPatrol;
    public GameObject StrongEnemy;
    

    private void Start()
    {
        EnemyPatrol = StrongEnemy.GetComponent<enemyPatrol>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyPatrol.enemyDeath == true)
        {
            gameObject.SetActive(false);
            Debug.Log("Wall ist nicht da");

        }
    }
}
