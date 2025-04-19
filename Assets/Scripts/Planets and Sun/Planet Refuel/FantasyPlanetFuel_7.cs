using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class FantasyPlanetFuel_7 : MonoBehaviour
{
    public ShipFuelManager fuelManagerReference;
    public bool hasAddedFuelToShip = false;
    public TextMeshProUGUI fuelTextConfirmationReference;

    private void Start()
    {
        fuelTextConfirmationReference.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && hasAddedFuelToShip == false)
        {
            fuelManagerReference.AddFuel(70);
            hasAddedFuelToShip = true;
            Debug.Log("Fantasy Planet 7 Fueled ship");
            ShowFuelTextConfirmation();
        }
    }

    private void ShowFuelTextConfirmation()
    {
        StartCoroutine(FlashTextOfUpgradedFuelTank());
    }

    IEnumerator FlashTextOfUpgradedFuelTank()
    {
        fuelTextConfirmationReference.enabled = true;
        yield return new WaitForSeconds(1.5f);
        fuelTextConfirmationReference.enabled = false;
    }
}
