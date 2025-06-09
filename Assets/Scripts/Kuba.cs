using UnityEngine;

public class Kuba : MonoBehaviour
{
    [SerializeField] KubaDialogues kubaDialogues;
    [Header("Kuba Dialogues")]
    [SerializeField] Dialogue Q1Dialogue; 
    private void Start()
    {
        GameEventsManager.instance.questEvents.onFinishQuest += EndQuest1Dialogue;
    }
    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onFinishQuest -= EndQuest1Dialogue;
    }

    private void EndQuest1Dialogue(string id)
    {
        if (id == "Quest1")
        {
            kubaDialogues.StopAllCoroutines();
            kubaDialogues.StartDialogue(Q1Dialogue);
            GameEventsManager.instance.questEvents.StartQuest("Quest2"); //starts quest 2
        }
    }
}
