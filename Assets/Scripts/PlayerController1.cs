using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;

    private Animator animator;
    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from horizontal and vertical axes
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement vector based on input
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        // Set the animator parameters based on movement speed
        float speed = movement.magnitude;
        animator.SetFloat("Speed", speed);

        // Rotate the player to face the direction of movement
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }

    void FixedUpdate()
    {
        // Move the player based on movement vector
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
    }
}
