using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;

    public Dialogue dialogue;
    private PlayerMovement player;

    private DialogueSystem DialogueSystem;

    private void Start()
    {
        DialogueSystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DialogueSystem>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public bool CanInteract()
    {
        return !DialogueSystem.isDialogueActive;

    }

    public void Interact()
    {

        if (DialogueSystem.isDialogueActive)
        {
            DialogueSystem.NextLine();
        }
        else
        {
            DialogueSystem.StartDialogue(dialogue);
        }

    }

    
}
