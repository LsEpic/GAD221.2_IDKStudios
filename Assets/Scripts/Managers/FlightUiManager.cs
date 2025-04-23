using System;
using UnityEngine;

public class FlightUiManager : MonoBehaviour
{
    public GameObject tutorialPanel;

    private void Start()
    {
        tutorialPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Time.timeScale = 0;
            tutorialPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void CloseUi()
    {
        Time.timeScale = 1;
        tutorialPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
