using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ConstantRotatingAsteroid : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(Random.Range(0, 360),Random.Range(0, 360),Random.Range(0, 360)) * (Time.deltaTime * 10f));
    }
}
