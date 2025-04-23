using UnityEngine;

public class UniversalPlanetGravity : MonoBehaviour
{
    public bool playerInGravityField = false;
    public Rigidbody playerRigidbodyReference;
    
    public float gravityStrength;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInGravityField = true;
            playerRigidbodyReference = other.gameObject.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInGravityField = false;
            playerRigidbodyReference = null;
        }
    }

    private void FixedUpdate()
    {
        if (playerInGravityField)
        {
            DragPlayerTowardsMiddleOfPlanet();
            
            if (Input.GetKey(KeyCode.X))
            {
                AlignPlayersCameraWithPlanet();
            }
        }
    }

    private void DragPlayerTowardsMiddleOfPlanet()
    {
        if (playerRigidbodyReference)
        {
            Vector3 gravityDirection = (transform.position - playerRigidbodyReference.transform.position).normalized;
            
            playerRigidbodyReference.AddForce(gravityDirection * gravityStrength, ForceMode.Acceleration);
        }
    }

    private void AlignPlayersCameraWithPlanet()
    {
        Vector3 gravityDirection = (transform.position - playerRigidbodyReference.transform.position).normalized;
        
        Quaternion targetRotation = Quaternion.FromToRotation(playerRigidbodyReference.transform.up, -gravityDirection) * playerRigidbodyReference.rotation;
        playerRigidbodyReference.rotation = Quaternion.Slerp(playerRigidbodyReference.rotation, targetRotation, 5f * Time.deltaTime);
    }
}
