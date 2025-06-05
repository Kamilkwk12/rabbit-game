using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class QuestManager : MonoBehaviour
{

    public VisualTreeAsset questUITemplate;

    public Quest[] questList;
    private UIDocument gameUi; 
    private VisualElement questUi;
    public Quest currentQuest;
    private void Start()
    {

        gameUi = GameObject.FindGameObjectWithTag("GameUI").GetComponent<UIDocument>();
        questUi = questUITemplate.Instantiate().Children().FirstOrDefault();
        questUi.style.display = DisplayStyle.None;
        gameUi.rootVisualElement.Q("GameUI").Add(questUi);
        questUi = gameUi.rootVisualElement.Q("QuestContainer");

        StartQuest(0);

    }

    public void StartQuest(int questID)
    {
        foreach (Quest quest in questList)
        { //deactivate all quests
            quest.isQuestActive = false;
        }

        currentQuest = questList[questID];

        if (!currentQuest.isQuestCompleted)
        {
            currentQuest.isQuestActive = true;

            questUi.Q<Label>("QuestName").text = currentQuest.questName;
            questUi.Q<Label>("QuestDescription").text = currentQuest.questDescription;
            questUi.style.display = DisplayStyle.Flex;
        }
        else return;
    }

    public void EndQuest(int questID)
    {
        if (currentQuest == questList[questID])
        {
            currentQuest.isQuestCompleted = true;

            questUi.style.display = DisplayStyle.None;
            questUi.Q<Label>("QuestName").text = "";
            questUi.Q<Label>("QuestDescription").text = "";

        }
    }
}
