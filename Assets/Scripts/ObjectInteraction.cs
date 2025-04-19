using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectInteraction : MonoBehaviour
{

    public ComputerUIScript Computer;

    [SerializeField] private TextMeshProUGUI _interactionText;

    private InputAction _interactionAction;

    


    private bool _canBeInteracted = false;

    void Awake()
    {
        _interactionText.enabled = false;
        _interactionAction = InputSystem.actions.FindAction("Interaction");
    }

    void Update()
    { 
        if (_canBeInteracted && _interactionAction.WasPressedThisFrame())
        {
            Debug.Log("Pressed E - interaction occurs");
            Computer.OpenWindow();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            _interactionText.enabled = true;
            _canBeInteracted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interactionText.enabled = false;
        _canBeInteracted = false;

    }
}
