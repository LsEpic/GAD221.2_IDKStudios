using UnityEngine;

public class FantasyPlanetFuel_5 : MonoBehaviour
{
    public ShipFuelManager fuelManagerReference;
    public bool hasAddedFuelToShip = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && hasAddedFuelToShip == false)
        {
            fuelManagerReference.AddFuel(50);
            hasAddedFuelToShip = true;
            Debug.Log("Fantasy Planet 5 Fueled ship");
        }
    }
}
