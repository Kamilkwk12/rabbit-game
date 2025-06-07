using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;

    public Dialogue dialogue;
    private PlayerMovement player;

    private DialogueSystem dialogueSystem;

    private void Start()
    {
        dialogueSystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DialogueSystem>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public bool CanInteract()
    {
        return !dialogueSystem.isDialogueActive;

    }

    public void Interact()
    {

        if (dialogueSystem.isDialogueActive)
        {
            dialogueSystem.NextLine();
        }
        else
        {
            dialogueSystem.StartDialogue(dialogue);
        }
    }
}
