using UnityEngine;
using UnityEngine.UI;

public class RefuelMiniGame : MonoBehaviour
{
    public ShipFuelManager fuelManager;
    
    public GameObject gamePanel;
    
    public Slider needleSlider;
    public RectTransform greenZone;
    public float needleSpeed = 1f;

    private bool increasing = true;
    private bool isActive = false;
    private int hitsNeeded = 1;
    private int hitsDone = 0;

    public void StartMinigame(int difficultyLevel)
    {
        Time.timeScale = 0f;
        gamePanel.SetActive(true);
        isActive = true;
        hitsNeeded = difficultyLevel;
        hitsDone = 0;
        
        float zoneWidth = Mathf.Lerp(0.4f, 0.1f, difficultyLevel / 10f);

        greenZone.anchorMin = new Vector2(0.5f - zoneWidth / 2f, 0f);
        greenZone.anchorMax = new Vector2(0.5f + zoneWidth / 2f, 1f);
    }

    void Update()
    {
        if (!isActive) return;
        
        needleSlider.value += (increasing ? 1 : -1) * needleSpeed * Time.unscaledDeltaTime;
        if (needleSlider.value >= 1f) increasing = false;
        else if (needleSlider.value <= 0f) increasing = true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsInGreenZone())
            {
                hitsDone++;
                if (hitsDone >= hitsNeeded)
                {
                    WinMinigame();
                }
            }
            else
            {
                FailMinigame();
            }
        }
    }

    bool IsInGreenZone()
    {
        float greenMin = greenZone.anchorMin.x;
        float greenMax = greenZone.anchorMax.x;
        return needleSlider.value >= greenMin && needleSlider.value <= greenMax;
    }

    void WinMinigame()
    {
        gamePanel.SetActive(false);
        Debug.Log("Minigame complete!");
        gamePanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        
        fuelManager.AddFuel(200);
    }

    void FailMinigame()
    {
        //fail scene or popup
        Debug.Log("Failed to refuel!");
    }
}
