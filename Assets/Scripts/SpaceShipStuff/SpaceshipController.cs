using System;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float thrustPower = 5f;
    public float maxSpeed = 20f;
    public float rotationSpeed = 2f;
    public float rollSpeed = 50f;
    public float fuelLeakAmount;

    private Rigidbody rb;
    public ShipFuelManager fuelManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            LimitSpeed();
        }
    }

    void FixedUpdate()
    {
        HandleThrust();
        HandleRotation();
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
        if (!fuelManager.HasFuel())
            return;
        
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

    private void OnCollisionEnter(Collision other)
    {
        fuelManager.LeakFuel(fuelLeakAmount);
    }
}
