using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoKeyDoor : MonoBehaviour
{
    PlayerMovement playerMovement;
    public BoxCollider2D boxCol1;
    public BoxCollider2D boxCol2;


    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && playerMovement.has2Keys == true)

        {
            Debug.Log("OPEN");
            
            boxCol1.enabled = false;
            boxCol2.enabled = false;
        }

    }

}
