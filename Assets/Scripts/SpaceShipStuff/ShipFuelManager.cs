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
}
