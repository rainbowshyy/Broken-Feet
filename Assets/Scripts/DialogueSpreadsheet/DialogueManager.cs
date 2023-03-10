using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialogueDataContainer dialogueData;

    [SerializeField] private TextMeshProUGUI cutsceneText;
    [SerializeField] private TextMeshProUGUI dialogueNameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Animator fade;

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
        DialogueData d = dialogueData.dialogueData.Find(dialogue => dialogue.Id == name);

        StartCoroutine(DialogueText(d.Text, d.Speaker, d.Time, d.Audio));
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

    private IEnumerator CutsceneText(string text, float time, string audio)
    {
        AudioManager.Instance.Play(audio);

        cutsceneText.text = text;
        yield return new WaitForSeconds(time);
        cutsceneText.text = "";

        AudioManager.Instance.Stop(audio);
    }

    public void Fade(bool doFade)
    {
        fade.SetBool("fadeOut", doFade);
    }

    public void PlayCutscene(string name)
    {
        DialogueData d = dialogueData.dialogueData.Find(dialogue => dialogue.Id == name);

        StartCoroutine(CutsceneText(d.Text, d.Time, d.Audio));
    }

    public void ShowDiaryEntry(int id)
    {
        DialogueData d = dialogueData.dialogueData.Find(dialogue => dialogue.Id == DiaryManager.Instance.entries[id]);

        DiaryManager.Instance.ShowEntry(d.Text, d.Speaker);
    }
}
