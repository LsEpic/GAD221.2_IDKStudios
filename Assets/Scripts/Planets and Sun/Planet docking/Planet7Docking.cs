using System;
using TMPro;
using UnityEngine;

public class Planet7Docking : MonoBehaviour
{
    public bool playerAbleToDock = false;
    public bool playerDocked = false;
    public GameObject ableToDockText;
    public GameObject dockedText;

    private void Start()
    {
        ableToDockText.SetActive(false);
        dockedText.SetActive(false);
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
            ableToDockText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerAbleToDock = false;
            ableToDockText.SetActive(false);
        }
    }

    private void DockingTheShipOnTopOfPlanetSurface()
    {
        if (!playerDocked)
        {
            playerAbleToDock = false;
            ableToDockText.SetActive(false);
            dockedText.SetActive(true);
            playerDocked = true;
            Debug.Log("Player Should be docked now!");
            
            // THE DOCKING SCRIPT GOES HERE MAYBE //////////////////////////////////////////////////////////////////////
        }
    }

    private void UnDockingTheShipOnTopOfPlanetSurface()
    {
        if (playerDocked)
        {
            playerAbleToDock = true;
            ableToDockText.SetActive(true);
            dockedText.SetActive(false);
            playerDocked = false;
            Debug.Log("Player Should be undocked now!");
            
            // THE UNDOCKING SCRIPT GOES HERE MAYBE //////////////////////////////////////////////////////////////////////
        }
    }
}
