using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    

    public bool moon = false;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoonCollision()
    {
        moon = true;
        Debug.Log("Picked up doctor");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            MoonCollision();    
        }
    }
}
