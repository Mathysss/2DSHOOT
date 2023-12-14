using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExplode : MonoBehaviour
{
    public GameObject Wall;

    public bool canPressWall = false;
    private float timesButtonPressed = 0;

 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player is in radius of the button");
            canPressWall = true;

        }
    }
    private void Update()
    {
        if (canPressWall == true && timesButtonPressed == 0 )
        {
            if (Input.GetKey("e"))
            {
                Debug.Log("Button Pressed");
                Wall.SetActive(false);
                PressButton();
                timesButtonPressed++;
                
            }
        }
    }
    public void PressButton()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
        AudioManager.instance.PlaySFX("Button");
    }


}
