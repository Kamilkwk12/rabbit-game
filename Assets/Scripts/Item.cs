using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;

    public Dialogue dialogue;

    private DialogueSystem dialogueSystem;
    private void Start()
    {
        dialogueSystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DialogueSystem>();
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
    }
}
