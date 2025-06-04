using UnityEngine;

public class EditableObject : MonoBehaviour, IInteractable
{
    public bool isActive;
    //[SerializeField] private bool _canBeEdited = true;

    public ScriptableObject objectData; 

    private GameManager _gameManager;
    private ComputerUI _computer;

    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _computer = GameObject.FindGameObjectWithTag("ComputerUI").GetComponent<ComputerUI>();

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    public void Activate() {
        _spriteRenderer.enabled = true;
        _boxCollider.enabled = true;
        _spriteRenderer.color = Color.white;
    }

    public void Deactivate()
    {
        _spriteRenderer.enabled = false;
        _boxCollider.enabled = false;
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
