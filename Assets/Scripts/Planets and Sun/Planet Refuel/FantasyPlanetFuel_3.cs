using UnityEngine;

public class FantasyPlanetFuel_3 : MonoBehaviour
{
    public ShipFuelManager fuelManagerReference;
    public bool hasAddedFuelToShip = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && hasAddedFuelToShip == false)
        {
            fuelManagerReference.AddFuel(30);
            hasAddedFuelToShip = true;
            Debug.Log("Fantasy Planet 3 Fueled ship");
        }
    }
}
