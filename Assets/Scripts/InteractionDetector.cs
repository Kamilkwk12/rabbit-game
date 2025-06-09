using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{

    public IInteractable _interactableInRange; //closest interactable
    public GameObject interactableGameObject;
    private DialogueSystem dialogueSystem;

    private void Start()
    {
        dialogueSystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DialogueSystem>();

        _interactableInRange = null;
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _interactableInRange?.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
        {
            interactableGameObject = collision.gameObject;
            _interactableInRange = interactable;
            Debug.Log($"Interaction avaliable for {collision.name}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.TryGetComponent(out IInteractable interactable) && _interactableInRange == interactable)
        {
            if (dialogueSystem.isDialogueActive)
            {
                dialogueSystem.EndDialogue();
            }
            interactableGameObject = null;
            _interactableInRange = null;
        }
    }
}