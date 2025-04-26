using UnityEngine;
using TMPro;
using System.Collections;

public class PopupTextManager : MonoBehaviour
{
    public static PopupTextManager Instance;

    [Header("UI References")]
    public GameObject popupPrefab;     // Assign your PopupTextUI prefab
    public Transform popupParent;      // Usually a canvas
    public float displayTime = 15f;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void ShowPopup(string message, float duration = -1f)
    {
        GameObject popup = Instantiate(popupPrefab, popupParent);
        TMP_Text textComponent = popup.GetComponentInChildren<TMP_Text>();

        float time = duration > 0 ? duration : displayTime;
        StartCoroutine(TypeTextAndDestroy(textComponent, message, popup, time));
    }

    private IEnumerator TypeTextAndDestroy(TMP_Text textComponent, string message, GameObject popup, float time)
    {
        textComponent.text = ""; // Clear the text first
        float delayPerChar = 0.03f; // Adjust for speed

        foreach (char c in message)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(delayPerChar);
        }

        yield return new WaitForSeconds(time);
        Destroy(popup);
    }
}
