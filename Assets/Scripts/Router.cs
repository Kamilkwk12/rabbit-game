using UnityEngine;

public class Router : MonoBehaviour, IInteractable
{
    private GameManager gameManager;
    private ComputerUI computer;
    private QuestManager questManager;
    private Kuba kuba;
    public bool routerInteractionActive { get; private set; } = true;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        computer = GameObject.FindGameObjectWithTag("ComputerUI").GetComponent<ComputerUI>();
        questManager = gameManager.GetComponent<QuestManager>();
        kuba = GameObject.FindGameObjectWithTag("Kuba").GetComponent<Kuba>();
    }

    public bool CanInteract()
    {
        return routerInteractionActive; 
    }

    public void Interact()
    {
        if (CanInteract())
        {
            if (gameManager.pendrivePluggedToRouter)
            {
                gameManager.ChangeGameState();
                computer.TerminalLog("Game state changed");

            }

            if (!gameManager.pendrivePickedUp && !gameManager.pendrivePluggedToRouter)
            {
                Debug.Log("PLayer cannot interact with router - access denied");
            }

            if ( gameManager.pendrivePickedUp && !gameManager.pendrivePluggedToRouter)
            {
                gameManager.UsePendrive();
                computer.RemoveIcon("readme.txt");
                computer.RemoveIcon("unknown.exe");
                computer.TerminalLog("Pendrive disconnected");
                computer.TerminalLog("Access to the router gained");

                questManager.EndQuest(0);

                kuba.StopAllCoroutines();
                kuba.StartCoroutine(kuba.TypeLine(Kuba.KubaDialogueType.QuestCompleted, 0));
            }
        }

    }
}
