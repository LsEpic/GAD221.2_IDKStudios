using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipFuelManager : MonoBehaviour
{
    [Header("Fuel Settings")]
        public float maxFuel = 200f;
        public float currentFuel;
        public float fuelDrainRate = 20f; // per second
        public bool isUsingFuel;
        
        public Slider fuelSlider;
        public TMP_Text outOfFuelText;
        
        //Leak fuel UI additions
        [SerializeField] private Image damageFlashImage;
        [SerializeField] private float flashDuration = 0.4f;
        [SerializeField] private Color flashColor = new Color(1f, 0f, 0f, 0.5f);
        
        public bool CanUseFuel => currentFuel > 0f;
    
        private void Start()
        {
            currentFuel = 150f;
            UpdateFuelUI();
        }
    
        private void Update()
        {
            if (isUsingFuel && CanUseFuel)
            {
                UseFuel();
            }

            UpdateFuelUI();
            
            if (!CanUseFuel)
            {
                outOfFuelText.enabled = true;
            }
            else
            {
                outOfFuelText.enabled = false;
            }
        }
    
        private void UseFuel()
        {
            currentFuel -= fuelDrainRate * Time.deltaTime;
            currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);
        }
        
        private void UpdateFuelUI()
        {
            if (fuelSlider != null)
            {
                fuelSlider.value = currentFuel / maxFuel;
            }
        }
    
        public bool HasFuel()
        {
            return currentFuel > 0;
        }
        
        public void AddFuel(float amount) // Method for later on when we want to give player more fuel
        {
            currentFuel = Mathf.Clamp(currentFuel + amount, 0f, maxFuel);
            UpdateFuelUI();
        }

        public void LeakFuel(float amount)
        {
            Debug.Log("Fuel Leaked!");
            currentFuel = Mathf.Clamp(currentFuel - amount, 0f, maxFuel);
            UpdateFuelUI();
            StartCoroutine(FlashDamage());
        }
        
        private IEnumerator FlashDamage()
        {
            if (damageFlashImage == null) yield break;
            
            damageFlashImage.color = flashColor;
            damageFlashImage.enabled = true;

            float elapsedTime = 0f;
            Color startColor = flashColor;
            Color endColor = new Color(flashColor.r, flashColor.g, flashColor.b, 0f);

            while (elapsedTime < flashDuration)
            {
                elapsedTime += Time.deltaTime;
                damageFlashImage.color = Color.Lerp(startColor, endColor, elapsedTime / flashDuration);
                yield return null;
            }

            damageFlashImage.enabled = false;
        }
}
