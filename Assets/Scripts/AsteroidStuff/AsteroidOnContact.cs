using System;
using System.Collections;
using UnityEngine;

public class AsteroidOnContact : MonoBehaviour
{
    public AsteroidSpawner asteroidSpawnerReference;

    private void Awake()
    {
        asteroidSpawnerReference = GameObject.FindGameObjectWithTag("AsteroidSpawner").GetComponent<AsteroidSpawner>();
        StartCoroutine(StartCountDownToDestruction());
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 7)
        {
            StartCoroutine(StartCountDownToDestruction());
        }
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartCountDownToDestruction());
        }
    }

    IEnumerator StartCountDownToDestruction()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
        asteroidSpawnerReference.thereIsAAsteroidInScene = false;
    }
}
