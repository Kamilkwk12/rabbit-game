using TMPro;
using UnityEngine;
using System.Collections.Generic;
public class QuestManager : MonoBehaviour
{
    public Quest[] quests;
    public Quest currentQuest;
    private PlayerStatus playerStatus;
    [SerializeField] private Canvas questUi;

    [SerializeField] private TextMeshProUGUI questTitle;
    [SerializeField] private TextMeshProUGUI questInfo;

    private void Start()
    {
        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
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

    public void CheckQuestConditions(int questID, string givenCondition)
    {
        if (quests[questID].questConditions.Contains(givenCondition))
        {
            playerStatus.AddCondition(questID, givenCondition);
            Debug.Log("Condition met");
        }
    }
}
