using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{

    public IInteractable _interactableInRange; //closest interactable

    private void Start()
    {
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
            _interactableInRange = interactable;
            Debug.Log($"Interaction avaliable for {collision.name}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && _interactableInRange == interactable)
        {
            _interactableInRange = null;
        }

    }
}
