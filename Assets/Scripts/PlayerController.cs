using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Get The RigidBody of the player that you want to apply some force on it
    private Rigidbody2D playerRb;
    // The move speed and turnSpeed
    [SerializeField] private float speed = 1.0f;
    // To Know if the player is moving now (when press on the moving button)
    private bool isMoving;
    [SerializeField] private float turnSpeed = 10;
    // To Know the direction of the rotation
    private float rotating = 0.0f;


    private void Awake()
    {
        // Get The RigidBody of the player that you want to apply some force on it 
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RotatePlayer();
        MovePlayer();

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
        // When Press On Turining Buttons Change the value of rotating variable to know the direction if it's left or right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            rotating = -1.0f;

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            rotating = 1.0f;

        else
            rotating = 0.0f;
    }

}
