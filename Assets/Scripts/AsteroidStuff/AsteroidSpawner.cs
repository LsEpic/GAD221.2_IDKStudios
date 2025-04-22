using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    public Transform playerReference;
    public GameObject asteroidPrefab;
    public GameObject newlySpawnedAsteroid;
    
    public bool thereIsAAsteroidInScene;

    public float asteroidSpeed = 100f;
    
    
    void FixedUpdate()
    {
        if (playerReference && thereIsAAsteroidInScene == false)
        {
            SpawnAsteroid();
        }
    }

    public void SpawnAsteroid()
    {
        Vector3 spawnPosition = playerReference.position + new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
        
        // Calculate direction from asteroid to player
        Vector3 directionToPlayer = (playerReference.position - spawnPosition).normalized;

        // Make the asteroid's Z-axis point at the player
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

        // Spawn the asteroid with correct rotation
        newlySpawnedAsteroid = Instantiate(asteroidPrefab, spawnPosition, lookRotation);
        
        thereIsAAsteroidInScene = true;
        
        //float randomScale = Random.Range(1f, 100f);
        //newlySpawnedAsteroid.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        
        FlingNewlyCreatedAsteroid(newlySpawnedAsteroid);
    }

    public void FlingNewlyCreatedAsteroid(GameObject newlyMadeAsteroid)
    {
        Vector3 directionToPlayer = (playerReference.position - newlyMadeAsteroid.transform.position).normalized;
        
        Rigidbody newlyMadeAsteroidRigidbody = newlyMadeAsteroid.GetComponent<Rigidbody>();
        if (newlyMadeAsteroidRigidbody != null)
        {
            newlyMadeAsteroidRigidbody.AddForce(directionToPlayer * asteroidSpeed, ForceMode.VelocityChange);
        }
        else
        {
            Debug.Log("No Asteroid Rigidbody found");
        }
    }
}
