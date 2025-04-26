using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPlanet : MonoBehaviour
{
    public ShipFuelManager fuelManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || GameManager.Instance.journalIndex >= 3)
        {
            fuelManager.AddFuel(150);
            GameManager.Instance.TriggerPlanetEvent(GameManager.Instance.GetNextJournalEntry());
            StartCoroutine(EndGame());
        }
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("Win Scene");
    }
}
