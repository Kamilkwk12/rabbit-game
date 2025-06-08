using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;

    public Dialogue dialogue;

    private DialogueSystem dialogueSystem;
    public QuestItem questItem;
    QuestManager questManager;
    private void Start()
    {
        dialogueSystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DialogueSystem>();
        questManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<QuestManager>();
    }

    public bool CanInteract()
    {
        return !dialogueSystem.isDialogueActive;

    }

    public void Interact()
    {

        if (dialogue)
        {
            if (dialogueSystem.isDialogueActive)
            {
                dialogueSystem.NextLine();
            }
            else
            {
                dialogueSystem.StartDialogue(dialogue);
                dialogueSystem.dialogueBoxTitle.text = itemName;
            }
        }

        if (questItem.questCondition != null && questItem.isQuestRelated)
        {
            questManager.CheckQuestConditions(0, questItem.questCondition);
        }

    }
}
