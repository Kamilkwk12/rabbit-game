using UnityEngine;

public class Pendrive : MonoBehaviour, IInteractable
{
    private ComputerUI _computer;
    public bool IsPickedUp {  get; private set; }

    public DesktopIcon virusData;
    public DesktopIcon textfileData;

    private void Start()
    {
        _computer = GameObject.FindGameObjectWithTag("ComputerUI").GetComponent<ComputerUI>();
    }

    public bool CanInteract()
    {
        return !IsPickedUp;
    }

    public void Interact()
    {
        if (!CanInteract()) return;
        //log action to terminal
        _computer.Log("rabbit@rabbit ~ $ pendrive connected");
        //show two files on computer
        _computer.AddDesktopIcon(virusData);
        _computer.AddDesktopIcon(textfileData);
        //note that player picked up pendrive
        IsPickedUp = true;
        //destroy game object
        gameObject.SetActive(false);

    }


}
