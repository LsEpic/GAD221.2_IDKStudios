using UnityEngine;

public class FantasyPlanetRotation_5 : MonoBehaviour
{
    public Transform whatToRotateAround;
    public float rotationSpeed = 30f;
    public Vector3 orbitTilt = Vector3.up; // Default: No tilt (straight up)
    public float maxTiltChange = 0.2f; // How much the tilt can change per adjustment
    public float orbitTiltChangeInterval = 2f; // Time between tilt adjustments (in seconds)

    [SerializeField] private float timer;

    void Start()
    {
        // Initialize with a slight random tilt
        orbitTilt = new Vector3(Random.Range(-0.2f, 0.2f), 1f, Random.Range(-0.2f, 0.2f)).normalized;
    }

    void Update()
    {
        transform.RotateAround(whatToRotateAround.position, whatToRotateAround.rotation * orbitTilt, rotationSpeed * Time.deltaTime);
        
        timer += Time.deltaTime;
        
        if (timer >= orbitTiltChangeInterval)
        {
            timer = 0f;
            ApplyRandomTiltChange();
        }
    }

    private void ApplyRandomTiltChange()
    {
        orbitTilt += new Vector3(Random.Range(-maxTiltChange, maxTiltChange), 0f, Random.Range(-maxTiltChange, maxTiltChange));

        // Normalize to maintain consistent rotation speed
        orbitTilt.Normalize();
    }
}
