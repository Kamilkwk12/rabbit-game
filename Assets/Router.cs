using UnityEngine;

public class Router : Item
{
    GameManager gameManager;
    public bool isRouterActive = false;
    private bool wasDialoguePlayed = false;
    private InteractionDetector interactionDetector;
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        interactionDetector = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<InteractionDetector>();
        onInteraction += GameStateSwitch;
    }

    private void GameStateSwitch()
    {
        if (isRouterActive && !dialogueSystem.isDialogueActive && interactionDetector.interactableGameObject == gameObject)
        {
            gameManager.WorldSwitch();
            wasDialoguePlayed = true;
        }
        if (wasDialoguePlayed) {
            dialogue = null;
        }
    }
}
