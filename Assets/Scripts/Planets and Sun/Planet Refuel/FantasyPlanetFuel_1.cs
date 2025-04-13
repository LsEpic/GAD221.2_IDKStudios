using System;
using UnityEngine;

public class FantasyPlanetFuel_1 : MonoBehaviour
{
    public ShipFuelManager fuelManagerReference;
    public bool hasAddedFuelToShip = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && hasAddedFuelToShip == false)
        {
            fuelManagerReference.AddFuel(10);
            hasAddedFuelToShip = true;
            Debug.Log("Fantasy Planet 1 Fueled ship");
        }
    }
}
