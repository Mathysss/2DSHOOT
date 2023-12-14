using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    PlayerMovement playerMovement;

    public void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && playerMovement.hasKey == true)
        {
            GetComponent<BoxCollider2D>().enabled = false;
           
        }
    }

}
