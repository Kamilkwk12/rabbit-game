using UnityEngine;

public class Router : MonoBehaviour, IInteractable
{
    private GameManager _gameManager;
    private ComputerUI _computer;
    public bool routerInteractionActive { get; private set; } = true;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _computer = GameObject.FindGameObjectWithTag("ComputerUI").GetComponent<ComputerUI>();
    }

    public bool CanInteract()
    {
        return routerInteractionActive; 
    }

    public void Interact()
    {
        if (CanInteract())
        {
            if (_gameManager.pendrivePluggedToRouter)
            {
                _gameManager.ChangeGameState();
                _computer.TerminalLog("Game state changed");

            }

            if (!_gameManager.pendrivePickedUp && !_gameManager.pendrivePluggedToRouter)
            {
                Debug.Log("PLayer cannot interact with router - access denied");
            }

            if ( _gameManager.pendrivePickedUp && !_gameManager.pendrivePluggedToRouter)
            {
                _gameManager.UsePendrive();
                _computer.RemoveIcon("readme.txt");
                _computer.RemoveIcon("unknown.exe");
                _computer.TerminalLog("Pendrive disconnected");
                _computer.TerminalLog("Access to the router gained");

                //open router minigame ??
            }
        }

    }
}
