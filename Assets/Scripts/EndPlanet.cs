using UnityEngine;

public class EndPlanet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || GameManager.Instance.journalIndex >= 3)
        {
            GameManager.Instance.TriggerPlanetEvent(GameManager.Instance.GetNextJournalEntry());
        }
    }
}
