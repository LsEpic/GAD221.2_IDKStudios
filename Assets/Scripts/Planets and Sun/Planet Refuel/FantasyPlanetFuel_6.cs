using UnityEngine;

public class FantasyPlanetFuel_6 : MonoBehaviour
{
    public ShipFuelManager fuelManagerReference;
    public bool hasAddedFuelToShip = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && hasAddedFuelToShip == false)
        {
            fuelManagerReference.AddFuel(60);
            hasAddedFuelToShip = true;
            Debug.Log("Fantasy Planet 6 Fueled ship");
        }
    }
}
