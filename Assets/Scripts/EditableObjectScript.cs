using UnityEngine;

public class EditableObjectScript : MonoBehaviour, IInteractable
{
    public bool isActive;
    //[SerializeField] private bool _canBeEdited = true;

    public ScriptableObject objectData; 

    private GameManager _gameManager;
    private ComputerUI _computer;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _computer = GameObject.FindGameObjectWithTag("ComputerUI").GetComponent<ComputerUI>();
    }

    public void Interact()
    {
        if (CanInteract()) {
            _computer.OpenWindow(ComputerUI.WindowType.EditWindow, this);
        }
    }

    public bool CanInteract()
    {
        if (_gameManager.virtualStateActive) { 
            return true;
        } else { return false; }
    }
}
