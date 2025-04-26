using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;

public class EndScreenUI : MonoBehaviour
{
    public TMP_Text text;
    
    [TextArea(5, 10)]
    public string endText;
    private float timer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(TypeTextAndDestroy(text, endText, timer));
    }

    private IEnumerator TypeTextAndDestroy(TMP_Text textComponent, string message, float time)
    {
        textComponent.text = ""; // Clear the text first
        float delayPerChar = 0.07f; // Adjust for speed

        foreach (char c in message)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(delayPerChar);
        }
        yield return new WaitForSeconds(time);
    }
}
