using System;
using System.Collections;
using UnityEngine;

public class TurnSunBlack : MonoBehaviour
{
    private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");
    public SunBecomeBlackHoleWhenNoFuel sunBecomeBlackHoleWhenNoFuelReference;

    public Material sunMaterial;
    public Material sunColourToGoBackTo;
    
    public float enlargeSpeed = 5f;

    public bool hasShownSunEqualBlackHoleMessage;
    
    
    
    // Update is called once per frame
    void Update()
    {
        if (sunBecomeBlackHoleWhenNoFuelReference.sunHasAlreadyBecomeBlackHole)
        {
            SunDarkensAndEnlarges();
        }
    }

    public void SunDarkensAndEnlarges()
    {
        if (!hasShownSunEqualBlackHoleMessage)
        {
            Debug.Log("Sun Darkens and Enlarging");
            hasShownSunEqualBlackHoleMessage = true;
        }
        
        Color currentColor = sunMaterial.GetColor(BaseColor);
        currentColor.r -= 0.3f * Time.deltaTime;
        currentColor.g -= 0.3f * Time.deltaTime;
        currentColor.b -= 0.3f * Time.deltaTime;
        sunMaterial.SetColor(BaseColor, currentColor);
        
        Vector3 newScale = transform.localScale;
        newScale += Vector3.one * (enlargeSpeed * Time.deltaTime);
        transform.localScale = newScale;
    }

    private void OnDisable()
    {
        sunMaterial.SetColor(BaseColor, sunColourToGoBackTo.GetColor(BaseColor));
    }
}
