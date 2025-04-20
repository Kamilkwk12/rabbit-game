using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectInteraction : MonoBehaviour
{

    private ComputerUIScript _computer;

    [SerializeField] private TextMeshProUGUI _interactionText;

    private InputAction _interactionAction;

    


    private bool _canBeInteracted = false;

    void Awake()
    {
        _computer = GameObject.FindGameObjectWithTag("ComputerUI").GetComponent<ComputerUIScript>();

        _interactionText.enabled = false;
        _interactionAction = InputSystem.actions.FindAction("Interaction");
    }


    void Update()
    { 
        if (_canBeInteracted && _interactionAction.WasPressedThisFrame())
        {
            Debug.Log("Pressed E - interaction occurs");
            _computer.OpenWindow();
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
