using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiaryManager : MonoBehaviour
{
    public static DiaryManager Instance { get; private set; }

    public string[] entries;

    [SerializeField] private TextMeshProUGUI dateText;
    [SerializeField] private TextMeshProUGUI textText;

    public int page;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        page = 1;
    }

    public void ShowEntry(string text, string date)
    {
        dateText.text = date;
        textText.text = text;
    }

    public void TurnPage(bool forward)
    {
        if (forward)
            page += 1;
        else
            page -= 1;
        if (page >= entries.Length)
            page = entries.Length - 1;
        else if (page < 0)
            page = 0;

        DialogueManager.Instance.ShowDiaryEntry(page);
    }
}
