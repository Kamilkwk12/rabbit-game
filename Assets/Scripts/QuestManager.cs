using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestManager : MonoBehaviour
{

    public VisualTreeAsset questUITemplate;

    public Quest[] questList;
    private UIDocument gameUi; 
    public Quest currentQuest;
    

    [SerializeField] private Canvas questUi;

    [SerializeField] private TextMeshProUGUI questTitle;
    [SerializeField] private TextMeshProUGUI questInfo;

    private void Start()
    {
        StartQuest(0);
    }

    public void StartQuest(int questID)
    {
        foreach (Quest quest in questList) //deactivate all quests DEBUG !!!!!!!!!!
        { 
            quest.isQuestActive = false;
            quest.isQuestCompleted = false;
        }

        currentQuest = questList[questID];

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
        if (currentQuest == questList[questID])
        {
            currentQuest.isQuestCompleted = true;

            questUi.enabled = false;
        }
    }
}
