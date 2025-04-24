using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [TextArea(5, 10)]
    public List<string> journalEntries = new List<string>();
    public int journalIndex = 0;
        
    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        PopupTextManager.Instance.ShowPopup(GetNextJournalEntry());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PopupTextManager.Instance.ShowPopup("This is a Test");
        }
    }
    
    public void TriggerPlanetEvent(string popupText)
    {
        PopupTextManager.Instance.ShowPopup(popupText);
    }
    
    public string GetNextJournalEntry()
    {
        if (journalIndex < journalEntries.Count)
        {
            string entry = journalEntries[journalIndex];
            journalIndex++;
            return entry;
        }
        else
        {
            return "You've seen all journal entries!";
        }
    }
}
