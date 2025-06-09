using UnityEngine;
using System;
public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;

    public Dialogue dialogue;

    public static event Action onInteraction;

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
        if (onInteraction != null)
        {
            onInteraction.Invoke();
        }

        if (dialogue)
        {
            if (dialogueSystem.isDialogueActive)
            {
                dialogueSystem.NextLine();
            }
            else
            {
                dialogueSystem.dialogueBoxTitle.text = itemName;
                dialogueSystem.StartDialogue(dialogue);
            }
        }
    }
}
