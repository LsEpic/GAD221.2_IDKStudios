using System.Collections;
using TMPro;
using UnityEngine;

public class FantasyPlanetFuel_2 : MonoBehaviour
{
    public ShipFuelManager fuelManagerReference;
    public bool hasAddedFuelToShip = false;
    public GameObject fuelTextConfirmationReference;
    
    private void Start()
    {
        fuelTextConfirmationReference.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && hasAddedFuelToShip == false)
        {
            fuelManagerReference.AddFuel(20);
            hasAddedFuelToShip = true;
            Debug.Log(">Fantasy Planet 2< Increased ship fuel tank!");
            ShowFuelTextConfirmation();
        }
    }
    
    private void ShowFuelTextConfirmation()
    {
        StartCoroutine(FlashTextOfUpgradedFuelTank());
    }

    IEnumerator FlashTextOfUpgradedFuelTank()
    {
        fuelTextConfirmationReference.GetComponent<TextMeshProUGUI>().text = ">Fantasy Planet 2< Increased ship fuel tank!";
        fuelTextConfirmationReference.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        fuelTextConfirmationReference.SetActive(false);
    }
}
