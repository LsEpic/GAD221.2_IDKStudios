using System;
using TMPro;
using UnityEngine;

public class Planet7Docking : MonoBehaviour
{
    public bool playerAbleToDock = false;
    public bool playerDocked = false;
    public TextMeshProUGUI ableToDockText;
    public TextMeshProUGUI dockedText;

    private void Start()
    {
        ableToDockText.enabled = false;
        dockedText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerAbleToDock)
        {
            DockingTheShipOnTopOfPlanetSurface();
        }

        if (Input.GetKeyDown(KeyCode.G) && playerDocked)
        {
            UnDockingTheShipOnTopOfPlanetSurface();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerAbleToDock = true;
            ableToDockText.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerAbleToDock = false;
            ableToDockText.enabled = false;
        }
    }

    private void DockingTheShipOnTopOfPlanetSurface()
    {
        if (!playerDocked)
        {
            playerAbleToDock = false;
            ableToDockText.enabled = false;
            dockedText.enabled = true;
            playerDocked = true;
            Debug.Log("Player Should be docked now!");
        }
    }

    private void UnDockingTheShipOnTopOfPlanetSurface()
    {
        if (playerDocked)
        {
            playerAbleToDock = true;
            ableToDockText.enabled = true;
            dockedText.enabled = false;
            playerDocked = false;
            Debug.Log("Player Should be undocked now!");
        }
    }
}
