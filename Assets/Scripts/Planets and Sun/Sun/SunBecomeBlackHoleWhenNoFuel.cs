using System.Collections;
using UnityEngine;

public class SunBecomeBlackHoleWhenNoFuel : MonoBehaviour
{
    public bool sunBeginTransitionToBlackHole;

    public float sunTransitionTimerToBecomingBlackHole;

    public bool hasShownSunCompleteMessage = false;
    
    public bool sunHasAlreadyBecomeBlackHole = false;

    // Update is called once per frame
    void Update()
    {
        if (sunBeginTransitionToBlackHole && !sunHasAlreadyBecomeBlackHole)
        {
            BeginSunTransition();
        }
    }

    public void BeginSunTransition()
    {
        sunTransitionTimerToBecomingBlackHole -= 1f * Time.deltaTime;
        
        if (sunBeginTransitionToBlackHole && sunTransitionTimerToBecomingBlackHole <= 0)
        {
            CompleteSunTransition();
        }
    }
    
    private void CompleteSunTransition()
    {
        sunHasAlreadyBecomeBlackHole = true;
        if (!hasShownSunCompleteMessage)
        {
            Debug.Log("Sun Transforming");
            hasShownSunCompleteMessage = true;
        }
    }
}
