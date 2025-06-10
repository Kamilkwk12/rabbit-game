using UnityEngine;

public class Kuba : MonoBehaviour
{
    [SerializeField] KubaDialogues kubaDialogues;
    [Header("Kuba Dialogues")]
    [SerializeField] Dialogue Q1Dialogue; 
    [SerializeField] Dialogue Q2Dialogue; 
    private void Start()
    {
        GameEventsManager.instance.questEvents.onFinishQuest += EndQuestDialogue;
    }
    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onFinishQuest -= EndQuestDialogue;
    }

    private void EndQuestDialogue(string id)
    {
        kubaDialogues.StopAllCoroutines();

        switch (id)
        {
            case "Quest1":
                kubaDialogues.StartDialogue(Q1Dialogue);
                GameEventsManager.instance.questEvents.StartQuest("Quest2"); 
                break;
            case "Quest2":
                kubaDialogues.StartDialogue(Q2Dialogue);
                GameEventsManager.instance.questEvents.StartQuest("Quest3"); 
                break;

            default:
                break;
        }
    }
}
