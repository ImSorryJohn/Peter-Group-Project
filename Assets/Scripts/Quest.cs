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
    
    public bool CheckInventoryRequirement()//string[] inventory)
    {
        foreach (var requirement in questRequirements)
        {
            bool found = false;

            foreach (var item in BagManager.Instance.Items)
            {
                if (item.itemName == requirement)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            return false;
        }
        return true;
    }

    public void RemoveQuestItems()
    {

        foreach (var requirement in questRequirements)
        {
            foreach (var item in BagManager.Instance.Items)
            {
                if (item.itemName == requirement)
                {
                    BagManager.Instance.Remove(item);
                    break;
                }
            }
        }
    }
}
