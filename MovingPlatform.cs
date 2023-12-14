using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public new Transform transform;
    public Transform posA, posB;
    public float Speed;

  

    Vector3 targetPos;

    PlayerMovement playerMovement;
    Rigidbody2D rb;
    Vector2 moveDirection;

    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();

    }



    void Start()
    {
        targetPos = posB.position;
        DirectionCalculate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < .1f)
        {
            targetPos = posB.position;
            DirectionCalculate();
        }


        if (Vector2.Distance(transform.position, posB.position) < .1f)
        {
            targetPos = posA.position;
            DirectionCalculate();
        }

    }  

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * Speed;
    }

    void DirectionCalculate()
    {
        moveDirection = (targetPos - transform.position).normalized;

    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {

            playerMovement.isOnPlatform = true;
            playerMovement.rbplatform = rb;
            
            
        }
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerMovement.isOnPlatform = false;


        }
    }

    

}
