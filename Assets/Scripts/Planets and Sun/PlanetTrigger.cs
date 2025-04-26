using TMPro;
using UnityEngine;

public class PlanetTrigger : MonoBehaviour
{
    public int difficultyLevel;
    public RefuelMiniGame refuelMiniGame;
    [SerializeField] private bool hasRefueledHere = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasRefueledHere == false)
        {
            hasRefueledHere = true;
            refuelMiniGame.StartMinigame(difficultyLevel);
        }
    }
}
