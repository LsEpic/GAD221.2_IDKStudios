using System;
using UnityEngine;

public class MenuUiManager : MonoBehaviour
{
    public GameObject controlsPanel;
    public GameObject menuPanel;

    private void Start()
    {
        controlsPanel.SetActive(false);
    }

    public void OpenControls()
    {
        menuPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void CloseControls()
    {
        menuPanel.SetActive(true);
        controlsPanel.SetActive(false);
    }
}
