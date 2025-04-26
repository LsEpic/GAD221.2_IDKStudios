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
            tutorialPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void CloseUi()
    {
        tutorialPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
