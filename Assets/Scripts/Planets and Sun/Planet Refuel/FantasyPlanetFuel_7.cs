using UnityEngine;

public class FantasyPlanetFuel_7 : MonoBehaviour
{
    public ShipFuelManager fuelManagerReference;
    public bool hasAddedFuelToShip = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && hasAddedFuelToShip == false)
        {
            fuelManagerReference.AddFuel(70);
            hasAddedFuelToShip = true;
            Debug.Log("Fantasy Planet 7 Fueled ship");
        }
    }
}
