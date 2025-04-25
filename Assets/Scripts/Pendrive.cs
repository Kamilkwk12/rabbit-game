using UnityEngine;

public class Pendrive : MonoBehaviour, IInteractable
{
    private ComputerUI _computer;
    private GameManager _gameManager;

    public DesktopIcon virusData;
    public DesktopIcon textfileData;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _computer = GameObject.FindGameObjectWithTag("ComputerUI").GetComponent<ComputerUI>();
    }

    public bool CanInteract()
    {
        return !_gameManager.isPendrivePickedUp;
    }

    public void Interact()
    {
        if (!CanInteract()) return;
        //log action to terminal
        _computer.TerminalLog("rabbit@rabbit ~ $ pendrive connected");
        //show two files on computer
        _computer.AddDesktopIcon(virusData);
        _computer.AddDesktopIcon(textfileData);
        //note that player picked up pendrive
        _gameManager.PendrivePickedUp();
        //destroy game object
        gameObject.SetActive(false);

    }


}
