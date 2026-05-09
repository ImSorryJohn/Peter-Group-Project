using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text speakerName;
    public TMP_Text speakerDialogue;

    public string[] dialogueCache;
    private int _dialogueIndex;
    public bool isActive;

    public void SetSpeakerName(string name)
    {
        speakerName.text = name;
    }

    public void SetSpeakerText(string text)
    {
        speakerDialogue.text = text;
        _dialogueIndex++;
    }

    public void SendSpeakerText(string[] TextCache)
    {
        dialogueCache = TextCache;
        _dialogueIndex = 0;
        SetSpeakerText(dialogueCache[_dialogueIndex]);
    }

    public void ToggleDialogue(bool isActive)
    {
        this.isActive = isActive;
        transform.GetChild(0).gameObject.SetActive(isActive);
    }

    public void OnProgressDialogue()
    {
        if (_dialogueIndex < dialogueCache.Length)
            SetSpeakerText(dialogueCache[_dialogueIndex]);
        else ToggleDialogue(false);
    }
}
