using UnityEngine;
using UnityEngine.UI;

public class ShipFuelManager : MonoBehaviour
{
    [Header("Fuel Settings")]
        public float maxFuel = 100f;
        public float currentFuel;
        public float fuelDrainRate = 20f; // per second
        public float fuelRegenRate = 10f; // per second
        public bool isUsingFuel;
        
        public Slider fuelSlider;
    
        private void Start()
        {
            currentFuel = maxFuel;
        }
    
        private void Update()
        {
            if (isUsingFuel)
            {
                UseFuel();
            }
            else
            {
                RegenerateFuel();
            }
            
            fuelSlider.value = currentFuel / maxFuel;
        }
    
        private void UseFuel()
        {
            currentFuel -= fuelDrainRate * Time.deltaTime;
            currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);
        }
    
        private void RegenerateFuel()
        {
            currentFuel += fuelRegenRate * Time.deltaTime;
            currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);
        }
    
        public bool HasFuel()
        {
            return currentFuel > 0;
        }
        
        public void AddFuel(float amount) // Method for later on when we want to give player more fuel
        {
            currentFuel = Mathf.Clamp(currentFuel + amount, 0f, maxFuel);
        }
}
