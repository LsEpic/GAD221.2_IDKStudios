using System;
using UnityEngine;

public class SunChecksPlayerFuel : MonoBehaviour
{
    public ShipFuelManager shipFuelManagerReference;

    public SunBecomeBlackHoleWhenNoFuel sunBecomeBlackHoleWhenNoFuelReference;
    
    public bool hasShownDebugMessage = false;
    
    public float sunTimerUntilDetonation = 20f;

    private void Start()
    {
        if (shipFuelManagerReference == null) {Debug.Log("No ship fuel manager found refernce!");}
    }

    // Update is called once per frame
    void Update()
    {
        if (shipFuelManagerReference)
        {
            if (shipFuelManagerReference.currentFuel > 1)
            {
                sunBecomeBlackHoleWhenNoFuelReference.sunBeginTransitionToBlackHole = false;
                sunBecomeBlackHoleWhenNoFuelReference.sunTransitionTimerToBecomingBlackHole = sunTimerUntilDetonation;
                hasShownDebugMessage = false;
            }
            
            if (shipFuelManagerReference.currentFuel < 1)
            {
                if (!hasShownDebugMessage)
                {
                    Debug.Log("Sun Detects Player has no fuel");
                    hasShownDebugMessage = true;
                }
                sunBecomeBlackHoleWhenNoFuelReference.sunBeginTransitionToBlackHole = true;
            }
        }
    }
}
