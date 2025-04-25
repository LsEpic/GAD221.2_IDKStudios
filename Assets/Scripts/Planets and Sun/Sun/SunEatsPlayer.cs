using UnityEngine;
using UnityEngine.SceneManagement;

public class SunEatsPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered sun and lose game");
            SceneManager.LoadScene(2);
        }
    }
}
