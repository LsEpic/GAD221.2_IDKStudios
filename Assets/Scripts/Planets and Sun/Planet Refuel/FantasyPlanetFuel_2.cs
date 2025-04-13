using UnityEngine;

public class FantasyPlanetFuel_2 : MonoBehaviour
{
    public ShipFuelManager fuelManagerReference;
    public bool hasAddedFuelToShip = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && hasAddedFuelToShip == false)
        {
            fuelManagerReference.AddFuel(20);
            hasAddedFuelToShip = true;
            Debug.Log("Fantasy Planet 2 Fueled ship");
        }
    }
}
