using UnityEngine;
using StarterAssets;

public class NPCController : MonoBehaviour
{

    //public Transform playerTransform;
    public DialogueManager dialogueManager;
    //private ThirdPersonController playerController; 

    public string characterName;
    public string[] introDialogue;

    private int _dialogueIndex;
    private bool _isFirstInteraction = true;

    public Quest[] quests; 
    public Quest activeQuest;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerController = playerTransform.GetComponentInParent<ThirdPersonController>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        quests = GetComponents<Quest>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFirstInteract()
    {
        if (_isFirstInteraction == false)
        {
            ServeQuest();
            return;
        }

        _isFirstInteraction = false;

        ConfigureDialogue(introDialogue);
    }

    public void ConfigureDialogue(string[] text)
    {
        dialogueManager.ToggleDialogue(true);
        dialogueManager.SetSpeakerName(characterName);
        dialogueManager.SendSpeakerText(text);
    }

    public void ServeQuest()
    {
        if (!activeQuest)
        {
            if (GetNextQuest() != null) activeQuest = GetNextQuest();
            else return;
        }

        switch (activeQuest.questState)
        {
            
            case QuestState.Intro:
                ConfigureDialogue(activeQuest.questStart);
                activeQuest.questState = QuestState.Served;
                break;
            case QuestState.Served:
                ConfigureDialogue(activeQuest.questGoal);
                if (activeQuest.CheckInventoryRequirement()) activeQuest.questState = QuestState.Complete;
                break;
            case QuestState.Complete:
                activeQuest.RemoveQuestItems();
                ConfigureDialogue(activeQuest.questEnd);
                activeQuest = null;
                break;
        }
    }

    public Quest GetNextQuest()
    {
        foreach (var quest in quests)
        {
            if (quest.questState == QuestState.Intro) return quest;    
        }

        return null;
    }
}
