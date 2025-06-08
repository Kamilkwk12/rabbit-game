using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Oven : Item
{
    private QuestStatus[] questStatuses;
    private Quest currentQuest;
    private QuestManager questManager;
    private void Start()
    {
        questStatuses = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>().questStatues;
        questManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<QuestManager>();
        currentQuest = GameObject.FindGameObjectWithTag("GameManager").GetComponent<QuestManager>().currentQuest;
    }

    public void UpdateQuest()
    {
        if (questStatuses[currentQuest.questId].conditions.Contains("cupboard") && questStatuses[currentQuest.questId].conditions.Contains("fridge"))
        {
            questManager.CheckQuestConditions("oven");
        }
    }
}
