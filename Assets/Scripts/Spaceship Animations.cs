using UnityEngine;

public class SpaceshipAnimations : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private bool isPowered;

    [SerializeField] private Transform bone003;
    private float rotationSpeed = 10f;


    private float currentXPos004;
    private float currentXPos012;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            isPowered = true;
        }
        else
        {
            isPowered = false;
        }

        animator.SetBool("isPowered", isPowered);

        Midotation();
    }

    void Midotation()
    {
        bone003.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
