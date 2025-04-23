using UnityEngine;

public class PlanetTrigger : MonoBehaviour
{
    public int difficultyLevel;
    public RefuelMiniGame refuelMiniGame;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            refuelMiniGame.StartMinigame(difficultyLevel);
        }
    }
}
