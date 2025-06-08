using System.Linq;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private QuestManager questManager;
    public QuestStatus[] questStatues;

    private void Start()
    {
        questManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<QuestManager>();
    }
    public void AddCondition(int questId, string condition)
    {
        if (!questStatues[questId].conditions.Contains(condition))
        {
            questStatues[questId].conditions.Add(condition);
            isQuestCompleted(questId);

        }
    }

    public void isQuestCompleted(int questId) 
    {
        if (questStatues[questId].conditions.SequenceEqual(questManager.currentQuest.questConditions)) {

            questManager.EndQuest(questId);
        }
    }
}
