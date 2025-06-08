using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class QuestManager : MonoBehaviour
{
    public Quest[] quests;
    public Quest currentQuest;
    private PlayerStatus playerStatus;
    [SerializeField] private Canvas questUi;

    [SerializeField] private TextMeshProUGUI questTitle;
    [SerializeField] private TextMeshProUGUI questInfo;
    private QuestStatus[] questStatues;

    private void Start()
    {
        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        questStatues = playerStatus.questStatues;
        StartQuest(0);
    }

    public void StartQuest(int questID)
    {

        currentQuest = quests[questID];

        if (!currentQuest.isQuestCompleted)
        {
            currentQuest.isQuestActive = true;


            questTitle.text = currentQuest.questName;
            questInfo.text = currentQuest.questDescription;
            questUi.enabled = true;

        }
        else return;
    }

    public void EndQuest(int questID)
    {
        if (currentQuest == quests[questID])
        {
            currentQuest.isQuestCompleted = true;

            questUi.enabled = false;
        }
    }

    public void CheckQuestConditions(string givenCondition)
    {
        if (currentQuest.questConditions.Contains(givenCondition))
        {
            playerStatus.AddCondition(currentQuest.questId, givenCondition);
            Debug.Log("Condition met");
        }
    }

    public void isQuestCompleted(int questId)
    {
        if (questStatues[questId].conditions.SequenceEqual(currentQuest.questConditions))
        {
            EndQuest(questId);
        }
    }
}
