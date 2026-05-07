using UnityEngine;
using TMPro;
using System.Linq;

public enum QuestState
{
    Intro,
    Served,
    Complete
}

public class Quest : MonoBehaviour
{
    [Header("Dialogue Variables")]
    public string[] questStart;
    public string[] questGoal;
    public string[] questEnd;

    public QuestState questState = QuestState.Intro;

    [Header("Inventory Requirement")]
    public string[] questRequirements;
    
    public bool CheckInventoryRequirement(string[] inventory)
    {
        foreach (var s in questRequirements)
        {
            if (!inventory.Contains(s)) return false;
        }
        return true;
    }
}
