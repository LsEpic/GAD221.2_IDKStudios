using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float thrustPower = 10f;  // Forward/Backward thrust
    public float strafePower = 7f;   // Left/Right/Up/Down thrust
    public float maxSpeed = 20f;     // Speed limit
    public float rotationSpeed = 2f; // Rotation speed

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = 0.1f;  
        rb.angularDamping = 0.1f; 
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
        LimitSpeed();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");   
        float moveY = Input.GetAxis("Jump") - Input.GetAxis("Fire3"); 
        float moveZ = Input.GetAxis("Vertical");     

        // Calculate movement force
        Vector3 moveForce = transform.right * moveX * strafePower +
                            transform.up * moveY * strafePower +
                            transform.forward * moveZ * thrustPower;

        // Apply it
        rb.AddForce(moveForce, ForceMode.Acceleration);
    }

    void HandleRotation()
    {
        // Mouse for direction, Q/E for Roll
        float pitch = -Input.GetAxis("Mouse Y");  // Inverted for natural feel
        float yaw = Input.GetAxis("Mouse X");
        float roll = (Input.GetKey(KeyCode.Q) ? 1f : 0f) - (Input.GetKey(KeyCode.E) ? 1f : 0f);

        // Create rotation vector
        Vector3 rotationInput = new Vector3(pitch, yaw, roll) * rotationSpeed;

        // Apply rotation force gradually
        rb.AddTorque(transform.TransformVector(rotationInput) * 0.5f, ForceMode.Acceleration);

        // Limit angular velocity to prevent excessive spinning
        rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, 2f);
    }

    void LimitSpeed()
    {
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}
