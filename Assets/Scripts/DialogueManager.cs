using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialogueStruct[] dialogues;

    [SerializeField] private TextMeshProUGUI dialogueNameText;
    [SerializeField] private TextMeshProUGUI dialogueText;

    public static DialogueManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayDialogue(string name)
    {
        DialogueStruct d = Array.Find(dialogues, dialogue => dialogue.name == name);

        StartCoroutine(DialogueText(d.text, d.speaker, d.seconds, d.audio));
    }

    private IEnumerator DialogueText(string text, string speaker, float time, string audio)
    {
        AudioManager.Instance.Play(audio);

        dialogueNameText.text = speaker;
        dialogueText.text = text;
        yield return new WaitForSeconds(time);
        dialogueNameText.text = "";
        dialogueText.text = "";

        AudioManager.Instance.Stop(audio);
    }
}

[System.Serializable]
public struct DialogueStruct
{
    public string name;
    public string audio;
    public string text;
    public string speaker;
    public float seconds;
}
