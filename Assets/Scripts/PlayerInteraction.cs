using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private InputAction _interactionAction;
    public bool _canBeInteracted = false;
    private GameObject _currentObject; //currently interacted object


    private ComputerScript _computer;
    void Awake()
    {
        _interactionAction = InputSystem.actions.FindAction("Interaction");
        _computer = GameObject.FindGameObjectWithTag("ComputerUI").GetComponent<ComputerScript>();
    }

    void Update()
    {
        if (_interactionAction.WasPressedThisFrame() && _canBeInteracted)
        {
            Debug.Log("Pressed E");
            _computer.Action(_currentObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item") || collision.CompareTag("Object")) {
            _canBeInteracted = true;
            _currentObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _canBeInteracted = false;
        _currentObject = null;
    }
}
