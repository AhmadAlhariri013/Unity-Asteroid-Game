using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Get The RigidBody of the player that you want to apply some force on it
    private Rigidbody2D playerRb;
    // The move speed and turnSpeed
    [SerializeField] private float speed = 5.0f;
    // To Know if the player is moving now (when press on the moving button)
    private bool isMoving;
    [SerializeField] private float turnSpeed = 45;
    // To Know the direction of the rotation
    private float rotating = 0.0f;
    // To Get the Explosion Effect 
    [SerializeField] private GameObject impactEffect;


    GameManager gameManager;
    private void Awake()
    {
        // Get The RigidBody of the player that you want to apply some force on it 
        playerRb = GetComponent<Rigidbody2D>();

        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        // If the player hasn't been died allow to move and rotate
        if (!gameManager.isGameOver)
        {
            RotatePlayer();
            MovePlayer();
        }


    }

    private void FixedUpdate()
    {
        // Make The Player Move to the top
        if (isMoving)
        {
            // !Note: we use transform to make the player move in LOCAL SPACE 
            // and that make the player move toward its facing now
            playerRb.AddForce(transform.up * speed);
        }

        // Turn The Player For The Riht or Lift
        if (rotating != 0.0f)
        {
            playerRb.AddTorque(rotating * turnSpeed);
        }

    }

    private void MovePlayer()
    {
        // When Press Moving Buttons Make This variable True
        isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
    }

    private void RotatePlayer()
    {
        //Rotating Using Keys
        // When Press On Turining Buttons Change the value of rotating variable to know the direction if it's left or right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            rotating = -1.0f;

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            rotating = 1.0f;

        else
            rotating = 0.0f;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When the player collid with the asteroid deactivate it and decrease the the chances
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            this.gameObject.SetActive(false);
            gameManager.PlayerDied();

            // Destroy the Asteroid
            Destroy(collision.gameObject);

            // On Collision Instantitate an effect 
            Instantiate(impactEffect, transform.position, transform.rotation);

        }
    }



}
