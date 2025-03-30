using UnityEngine;

public class CarEngineSound : MonoBehaviour
{
    public AudioSource revSound;  // Reference to the AudioSource for revving sound
    public AudioSource idleSound; // Reference to the AudioSource for idle sound
    public float revSpeed = 1.0f; // Speed of the rev sound change (optional)
    public float minRevPitch = 1.0f; // Minimum pitch for idle sound
    public float maxRevPitch = 2.0f; // Maximum pitch for revving sound

    private bool isRevving = false;

    void Start()
    {
        // Ensure both AudioSources are set up
        if (revSound == null)
        {
            revSound = GetComponent<AudioSource>(); // Assume the first AudioSource is for revving
        }

        if (idleSound == null)
        {
            idleSound = transform.GetChild(0).GetComponent<AudioSource>(); // Assuming idleAudioSource is the second AudioSource
        }

        // Start playing idle sound if the car is not moving or revving
        if (!idleSound.isPlaying)
        {
            idleSound.loop = true;
            idleSound.Play();
        }
    }

    void Update()
    {
        // Check if the car is moving or accelerating (e.g., pressing the 'W' key)
        if (Input.GetKey(KeyCode.W)) // Example for accelerating with 'W'
        {
            // If not already revving, start the revving sound
            if (!isRevving)
            {
                revSound.Play();
                isRevving = true;
            }

            // Adjust pitch based on simulated RPM (change this with your actual car speed/RPM)
            revSound.pitch = Mathf.Lerp(minRevPitch, maxRevPitch, Mathf.PingPong(Time.time * revSpeed, 1)); // Simulating RPM change

            // Stop the idle sound if the car is revving
            if (idleSound.isPlaying)
            {
                idleSound.Stop();
            }
        }
        else
        {
            // If not accelerating, stop revving sound and play idle sound
            if (isRevving)
            {
                revSound.Stop();
                isRevving = false;
            }

            // Start the idle sound if it's not already playing
            if (!idleSound.isPlaying)
            {
                idleSound.loop = true;
                idleSound.Play();
            }
        }
    }
}
