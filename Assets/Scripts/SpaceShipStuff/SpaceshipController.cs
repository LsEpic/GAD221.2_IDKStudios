using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float thrustPower = 10f;
    public float maxSpeed = 20f;
    public float rotationSpeed = 2f;
    public float rollSpeed = 50f;

    private Rigidbody rb;
    public ShipFuelManager fuelManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        HandleThrust();
        HandleRotation();
        LimitSpeed();
    }

    void HandleThrust()
    {
        bool thrustInput = Input.GetKey(KeyCode.W);

        if (thrustInput && fuelManager.HasFuel())
        {
            rb.AddForce(transform.forward * thrustPower, ForceMode.Acceleration);
            fuelManager.isUsingFuel = true;
        }
        else
        {
            fuelManager.isUsingFuel = false;
        }
    }

    void HandleRotation()
    {
        float pitch = -Input.GetAxis("Mouse Y"); // Inverted for flight
        float yaw = Input.GetAxis("Mouse X");
        float roll = (Input.GetKey(KeyCode.Q) ? 1f : 0f) - (Input.GetKey(KeyCode.E) ? 1f : 0f);

        Vector3 rotationInput = new Vector3(pitch, yaw, roll) * rotationSpeed;

        rb.AddTorque(transform.TransformVector(rotationInput) * 0.5f, ForceMode.Acceleration);
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
