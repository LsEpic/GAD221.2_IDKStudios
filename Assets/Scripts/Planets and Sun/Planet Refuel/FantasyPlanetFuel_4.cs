using UnityEngine;

public class FantasyPlanetFuel_4 : MonoBehaviour
{
    public ShipFuelManager fuelManagerReference;
    public bool hasAddedFuelToShip = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && hasAddedFuelToShip == false)
        {
            fuelManagerReference.AddFuel(40);
            hasAddedFuelToShip = true;
            Debug.Log("Fantasy Planet 4 Fueled ship");
        }
    }
}
