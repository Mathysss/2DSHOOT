using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{

    public GameObject bullet;
    public Vector2 bulletDirection;


    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Instantiate(bullet, transform.position, transform.rotation);
           
        }
    }
}
