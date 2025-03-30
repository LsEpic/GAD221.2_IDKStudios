using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject goalMessage;

    private void Start()
    {
        goalMessage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            goalMessage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            goalMessage.SetActive(false);
        }
    }
}
