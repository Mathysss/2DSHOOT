using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;

    public float health;
    public float maxhealth = 10f;

    //private bool doubleJump;
    public int ammountOfJumps = 2;
    private int realAmmountOfJumps;
    private int score = 0;
    public Text scoreText;
    private int keys;
    public Text keyText;
    public Text healthText;

    public bool isOnPlatform;
    public Rigidbody2D rbplatform;

    public Transform gun;


    public bool hasKey;
    public bool has2Keys;
    public float ammountOfKeys;

   




    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    public void Start()
    {
        health = maxhealth;
        healthText.GetComponent<Text>().text = "Health: " + health;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Lava")
        {
            AudioManager.instance.PlaySFX("PlayerDeath");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.tag == "Finish")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1;
        }
        if (collision.tag == "LastFinish")
        {
            SceneManager.LoadScene("Credits");
            AudioManager.instance.musicSource.Stop();
            AudioManager.instance.PlayMusic("Hymna");
            Time.timeScale = 1;
        }
        if (collision.tag == "Coin")
        {
            collision.gameObject.SetActive(false);
            score++;
            scoreText.GetComponent<Text>().text = "SCORE: " + score;
            AudioManager.instance.PlaySFX("CoinPickup");


        }
        if (collision.tag == "DoublePower")
        {
            ammountOfJumps = 2;
            collision.gameObject.SetActive(false);
            AudioManager.instance.PlaySFX("PowerUp");
        }
        if (collision.tag == "Key")
        {
            collision.gameObject.SetActive(false);
            hasKey = true;
            AudioManager.instance.PlaySFX("CoinPickup");
            keys++;
            keyText.GetComponent<Text>().text = "KEYS: " + keys;
        }
        if (collision.tag == "Key2")
        {
            collision.gameObject.SetActive(false);
            ammountOfKeys++;
            AudioManager.instance.PlaySFX("CoinPickup");
            Debug.Log("Ammount of Keys " + ammountOfKeys);
            keys++;
            keyText.GetComponent<Text>().text = "KEYS: " + keys;
        }

    }





    private void Update()
    {

     
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            // doubleJump = false;
            realAmmountOfJumps = ammountOfJumps;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || realAmmountOfJumps > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                // doubleJump = !doubleJump;
                realAmmountOfJumps--;
                Debug.Log("JUMPS: " + realAmmountOfJumps);
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();

        if (ammountOfKeys == 2)
        {
            has2Keys = true;
            Debug.Log("HAS 2 KEYS");
        } else
        {
            has2Keys = false;
        }



    }

    public void GunPickup()
    {
        gun.gameObject.SetActive(true);
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        healthText.GetComponent<Text>().text = "Health: " + health;
    }
    private void FixedUpdate()

    {
        if (isOnPlatform)
        {
            Debug.Log("THE PLAYER IS ON A PLATFORM");
            rb.velocity = new Vector2(horizontal * speed +  rbplatform.velocity.x, rb.velocity.y);
            Debug.Log(rb.velocity);
        }
        else
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }


       
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {

            isFacingRight = !isFacingRight;

            transform.Rotate(0, 180f, 0);
            

           
        }

        
    }
}